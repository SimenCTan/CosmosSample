using System.Linq;
using System.Threading.Tasks;
using CosmosSample.Data;
using CosmosSample.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Login/{loginname}/{encryptpwd}")] HttpRequest req,
            string loginname,
            string encryptpwd,
            ILogger log)
        {
            var response = new ResponseResult<string>();
            log.LogInformation($"{loginname} try login with pwd {encryptpwd}");
            var existMember = await _cosmosdbContext.MemberEntities
                .WithPartitionKey(loginname)
                .Where(m=>m.Password==encryptpwd)
                .FirstOrDefaultAsync();
            if (existMember == null)
            {
                response.Code = -1;
                response.Message = "login name and password not match";
            }
            else
            {
                response.Data = existMember.FullName;
            }
            return new OkObjectResult(response);
        }
    }
}
