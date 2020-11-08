using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPICore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            List<string> lstNama = new List<string>
            {
                "Erick","Budi","Bambang","Joni"
            };

            return lstNama;
        }

        [HttpGet("{nama}")]
        public string Get(string nama)
        {
            return $"Nama anda: {nama}";
        }

    }
}
