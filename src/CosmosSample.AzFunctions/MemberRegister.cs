using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CosmosSample.Domain.Configurations;
using CosmosSample.Data;
using Microsoft.Extensions.Options;
using CosmosSample.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CosmosSample_AzFunctions
{
    public class MemberRegister
    {
        private readonly CosmosContext _cosmosdbContext;
        public MemberRegister(IOptions<CosmosOptions> options,
            CosmosContext cosmosContext)
        {
            _cosmosdbContext = cosmosContext;
        }

        [FunctionName("MemberRegister")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string name = req.Query["name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            await _cosmosdbContext.Database.EnsureCreatedAsync();
            name = name ?? data?.name;
            try
            {
                var ddditem = await _cosmosdbContext.TodoItems.WithPartitionKey(name).FirstOrDefaultAsync();
                var newItem = new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "testgogo",
                    Description = "this is test"
                };
                _cosmosdbContext.Add(newItem);
                _cosmosdbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
