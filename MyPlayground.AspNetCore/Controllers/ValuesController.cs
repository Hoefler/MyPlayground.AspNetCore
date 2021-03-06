﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyPlayground.Data;

namespace MyPlayground.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<AppSettings> _options;
        private readonly IDocumentService _documentService;

        private ILogger<ValuesController> _logger { get; }

        public ValuesController(ILogger<ValuesController> logger, IOptions<AppSettings> options, IDocumentService documentService)
        {
            _logger = logger;
            _options = options;
            _documentService = documentService;
            _logger.LogDebug($"Setting1 = {_options.Value.Setting1}");
            _logger.LogDebug($"Setting2 = {_options.Value.Setting2}");

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogDebug("Get");
            return _documentService.GetDocuments().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
