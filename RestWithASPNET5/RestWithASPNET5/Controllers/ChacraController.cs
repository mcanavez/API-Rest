using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETMesaRadionica.Business;
using RestWithASPNETMesaRadionica.Model;
using System;

namespace RestWithASPNETMesaRadionica.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]    
    public class ChacraController : ControllerBase

    {
        private readonly ILogger<ChacraController> _logger;
        private  IChacrasBusiness _chacras;

        public ChacraController(ILogger<ChacraController> logger, IChacrasBusiness chacraBusiness)
        {
            _logger = logger; ;
            _chacras = chacraBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_chacras.ReturnAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var chacras = _chacras.FindById(id);
            if (chacras == null) return NotFound("Chacra not found!");
            return Ok(chacras);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Chacras chacra)
        {
            if (chacra == null) return BadRequest();
            return Ok(_chacras.Create(chacra));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Chacras chacra)
        {
            if (chacra == null) return BadRequest();
            return Ok(_chacras.Update(chacra));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _chacras.Delete(id);
            return NoContent();

        }
    }
}

