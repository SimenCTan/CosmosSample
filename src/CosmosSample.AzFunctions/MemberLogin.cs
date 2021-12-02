using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CosmosSample.Data;
using CosmosSample.Domain.Models;
using CosmosSample_AzFunctions.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CosmosSample.AzFunctions
{
    public class MemberLogin
    {
        private readonly CosmosContext _cosmosdbContext;
        public MemberLogin(CosmosContext cosmosContext)
        {
            _cosmosdbContext = cosmosContext;
        }

        [FunctionName("MemberLogin")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Users/Login")] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseResult<TokenInfo>();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation($"try login with login info {requestBody}");

            var loginInfo = JsonConvert.DeserializeObject<LoginRequest>(requestBody);
            var existMember = await _cosmosdbContext.MemberEntities
                .WithPartitionKey(loginInfo.Username)
                .Where(m=>m.Password==loginInfo.Password)
                .FirstOrDefaultAsync();
            if (existMember == null)
            {
                response.Code = -1;
                response.Message = "login name and password not match";
            }
            else
            {
                response.Data = new TokenInfo
                {
                    AccessToken = existMember.Id,
                    RefreshToken = existMember.Id,
                    LoginName = existMember.FullName,
                };
            }
            return new OkObjectResult(response);
        }
    }
}
