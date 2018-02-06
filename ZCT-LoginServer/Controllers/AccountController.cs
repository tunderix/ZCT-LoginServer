using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZCTLoginServer.Models;
using ZCTLoginServer.Services;

namespace ZCTLoginServer.Controllers
{
    [Route("api/accounts")]
    [Authorize]
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
        [Produces(typeof(LFAccount))]
        public async Task Post([FromBody]LFAccount account)
        {
            var mongoService = new MongoDbService("LF", "LFAccounts", "mongodb://localhost");
            await mongoService.InsertAccount(account);
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(LFAccount))]
        public ICActionResult Post(){
            
        }
    }
}
