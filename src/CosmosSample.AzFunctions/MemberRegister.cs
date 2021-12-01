using System;
using System.IO;
using System.Threading.Tasks;
using CosmosSample.Data;
using CosmosSample.Domain.Entities;
using CosmosSample.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CosmosSample_AzFunctions
{
    public class MemberRegister
    {
        private readonly CosmosContext _cosmosdbContext;
        public MemberRegister(CosmosContext cosmosContext)
        {
            _cosmosdbContext = cosmosContext;
        }

        [FunctionName("MemberRegister")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // await _cosmosdbContext.Database.EnsureDeletedAsync();
            // await _cosmosdbContext.Database.EnsureCreatedAsync();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation(requestBody);
            var memberEntity = JsonConvert.DeserializeObject<MemberEntity>(requestBody);
            var existMember = await _cosmosdbContext.MemberEntities.WithPartitionKey(memberEntity.Email).FirstOrDefaultAsync();
            if (existMember != null)
            {
                return new OkObjectResult(new StatusResponseResult { Code = -1, Message = "failed email has exist" });
            }
            memberEntity.Id = Guid.NewGuid().ToString();
            _cosmosdbContext.MemberEntities.Add(memberEntity);
            await _cosmosdbContext.SaveChangesAsync();
            return new OkObjectResult(new StatusResponseResult { Code = 0, Message = "success" });
        }
    }
}
