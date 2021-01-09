using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetChatApp.Models;
using DotnetChatApp.Database;
using Microsoft.EntityFrameworkCore;

namespace DotnetChatApp.Controllers
{
    [Route("api/{Controller}")]
    public class HomeController : ControllerBase
    {
        private readonly ModelContext db;

        public HomeController(ILogger<HomeController> logger, ModelContext db)
        {
            this.db = db;
        }

       
       public ActionResult GetAll()
       {
           // TODO: Your code here
           return Ok("hi");
       }
       
    }
}
