using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FirstVaultApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private readonly ILogger<SecretController> _logger;
        private readonly IConfiguration _configuration;

        public SecretController(ILogger<SecretController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _configuration.AsEnumerable().Where(x=>x.Key.Contains("secret")).Select(x=>x.Value);
        }
    }
}
