using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZCTLoginServer.Models;
using ZCTLoginServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZCTLoginServer.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoService = new MongoDbService("LF", "LFAccounts", "mongodb://localhost");
            var allAccounts = await mongoService.GetAllAccounts();

            return Json(allAccounts);
        }
        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]LFAccount account)
        {

            var mongoService = new MongoDbService("LF", "LFAccounts", "mongodb://localhost");
            await mongoService.InsertAccount(account);
        }
    }
}
