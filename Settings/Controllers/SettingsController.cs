using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Settings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IConfiguration _configuration;
        public SettingsController(ILogger<SettingsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public Dictionary<string, string> Get()
        {
            var switchMappings = new Dictionary<string, string>()
                                     {
                                         { "myKeyValue", _configuration["MyKey"] },
                                         { "nivel1", _configuration["Variaveis:Nivel1"] },
                                         { "nivel2", _configuration["Variaveis:Nivel2"] },
                                         { "nivel3", _configuration["Variaveis:Nivel3"] },
                                         { "nivel4", _configuration["Variaveis:Nivel4"] },
                                         { "nivel5", _configuration["Variaveis:Nivel5"] },
                                         { "nivel6", _configuration["Variaveis:Nivel6"] },
                                     };

            return switchMappings;
        }
    }
}
