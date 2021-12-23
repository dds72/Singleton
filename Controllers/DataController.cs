using System;
using Microsoft.AspNetCore.Mvc;
using Singleton.Models;

namespace Singleton.Controllers
{
    [Route("data")]
    public class DataController : Controller
    {
        private readonly Singleton singleton;

        public DataController(Singleton singleton)
        {
            this.singleton = singleton;
        }

        [HttpGet]
        public ActionResult GetA()
        {
            var rnd = new Random();
            this.singleton.Enqueue(new Job(rnd.Next(100000)));
            return Ok();
        }

    }
}

