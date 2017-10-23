﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sentio.MixedService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpGet]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpGet]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpGet]
        public void Delete(int id)
        {
        }
    }
}
