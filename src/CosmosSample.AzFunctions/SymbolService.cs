using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CosmosSample.Domain.Models;
using CosmosSample.Domain.Entities;
using CosmosSample.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using CosmosSample_AzFunctions.ViewModels;

namespace CosmosSample.AzFunctions
{
    public class SymbolService
    {
        private readonly CosmosContext _cosmosdbContext;
        private readonly IMapper _mapper;
        public SymbolService(CosmosContext cosmosContext,
            IMapper mapper)
        {
            _cosmosdbContext = cosmosContext;
            _mapper = mapper;
        }

        [FunctionName("GetDailyQuote")]
        public async Task<IActionResult> GetDailyQuote(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetDailyQuote/{tscode}")] HttpRequest req,
            string tscode,
            ILogger log)
        {
            var response = new ResponseResult<List<DailyQuoteViewModel>>();
            log.LogInformation($"get {tscode} daily quote");
            var existSymbol = await _cosmosdbContext.Symbols.WithPartitionKey(tscode).FirstOrDefaultAsync();
            if (existSymbol == null) return new BadRequestObjectResult(response.Code = -1);
            response.Data = _mapper.Map<List<DailyQuoteViewModel>>(existSymbol.DailyQuotes.OrderBy(m=>m.TradeDay));
            return new OkObjectResult(response);
        }


        [FunctionName("SaveDailyQuote")]
        public async Task<IActionResult> SaveDailyQuote(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // await _cosmosdbContext.Database.EnsureCreatedAsync();
            var response = new StatusResponseResult();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation($"save symbol {requestBody}");
            var symbolEntity = JsonConvert.DeserializeObject<SymbolEntity>(requestBody);
            if (symbolEntity.DailyQuotes.Count <= 0) return new BadRequestObjectResult(response.Code = -1);

            var existSymbol = await _cosmosdbContext.Symbols.WithPartitionKey(symbolEntity.TSCode).FirstOrDefaultAsync();
            if (existSymbol != null)
            {
                // add or update daily quote
                var newDailyQuotes = new List<DailyQuote>();
                var oldDailyQuotes = existSymbol.DailyQuotes.ToList();
                oldDailyQuotes.ForEach(old =>
                {
                    var dailyQuote = symbolEntity.DailyQuotes.Where(m => m.TradeDay == old.TradeDay).FirstOrDefault();
                    if (dailyQuote != null)
                    {
                        old.Amount = dailyQuote.Amount;
                        old.Volume = dailyQuote.Volume;
                        symbolEntity.DailyQuotes.Remove(dailyQuote);
                    }
                });
                newDailyQuotes.AddRange(oldDailyQuotes);
                newDailyQuotes.AddRange(symbolEntity.DailyQuotes);
                existSymbol.DailyQuotes = newDailyQuotes;
                _cosmosdbContext.Symbols.Update(existSymbol);
            }
            else
            {
                symbolEntity.Id = Guid.NewGuid().ToString();
                _cosmosdbContext.Symbols.Add(symbolEntity);
            }
            await _cosmosdbContext.SaveChangesAsync();
            return new OkObjectResult(response);

            #region remarks
            //symbolEntity.Id=Guid.NewGuid().ToString();
            //var bizDay = 20210718; //Convert.ToInt32(DateTime.Now.Date.ToString("yyyyMMDD"));
            //var dailyQuote = new DailyQuote
            //{
            //    TSCode="000001.SZ",
            //    TradeDay = bizDay,
            //    Open = 8.75m,
            //    High = 8.85m,
            //    Low = 8.69m,
            //    Close = 8.72m,
            //    PreClose = 8.72m,
            //    Change = -0.02,
            //    Volume = 525152.77,
            //    Amount = 460697.377m
            //};
            //var symbolEntity = new SymbolEntity
            //{
            //    Id=Guid.NewGuid().ToString(),
            //    TSCode = "000001.SZ",
            //    Symbol = "000001",
            //    Name = "平安银行",
            //    Area = "深圳",
            //    Industry = "银行",
            //    Market = "主板",
            //    Exchange = "SZA",
            //    Currency = "RMB",
            //    SymbolStatus = SymbolStatus.List,
            //    ListDay = 19910403
            //};
            #endregion
        }
    }
}
