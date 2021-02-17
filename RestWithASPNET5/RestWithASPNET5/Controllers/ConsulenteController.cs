using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETMesaRadionica.Business;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.HyperMedia.Filters;
using RestWithASPNETMesaRadionica.Model;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]   
    public class ConsulenteController : ControllerBase
    {
        private readonly ILogger<ConsulenteController> _logger;
        private IConsulenteBusiness _consulente;

        public ConsulenteController(ILogger<ConsulenteController> logger, IConsulenteBusiness consulenteBusiness)
        {
            _logger = logger; ;
            _consulente = consulenteBusiness;
        }

        
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ConsulenteVO))]        
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var consulente = _consulente.FindById(id);
            if (consulente == null) return NotFound("Consulente not found!");
            return Ok(consulente);
                        

        }

        [HttpGet("findConsulenteByName")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ConsulenteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string nome, [FromQuery] string sobreNome)
        {
            var consulente = _consulente.FindByName(nome, sobreNome);
            if (consulente == null) return NotFound("Consulente not found!");
            return Ok(consulente);

        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<ConsulenteVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(
           [FromQuery] string name,
           string sortDirection,
           int pageSize,
           int page)
        {
            return Ok(_consulente.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ConsulenteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ConsulenteVO consulente)
        {
            if (consulente == null) return BadRequest();
            return Ok(_consulente.Create(consulente));

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ConsulenteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] ConsulenteVO consulente)
        {
            if (consulente == null) return BadRequest();
            return Ok(_consulente.Update(consulente));

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _consulente.Delete(id);
            return NoContent();

        }

        [HttpPatch]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ConsulenteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch(long id)
        {
            var consulente = _consulente.Disable(id);
            return Ok(consulente);

        }
    }
}
       

