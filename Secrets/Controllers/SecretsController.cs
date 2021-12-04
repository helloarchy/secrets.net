using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Secrets.Models;

namespace Secrets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public SecretsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // var connectionString = Configuration["ConnectionString"];
            // var facebook = Configuration.GetSection("Facebook").Get<Facebook>();
            // return Ok($"Facebook secret = {facebook.AppSecret}, Facebook id = {facebook.AppId}");

            var myConnection = new SqlConnectionStringBuilder("Server=.;Database=SecretsApp;User=hardy")
            {
                Password = Configuration["DbPassword"]
            };
            return Ok(myConnection.ToString());
        }
    }
}