using Microsoft.AspNetCore.Mvc;
using Robo.Aplicacao.Comandos;
using Robo.Dominio;
using System;

namespace Robo.Api.Controllers
{
    [Route("rest/mars")]
    [ApiController]
    public class MarteController : ControllerBase
    {
        private readonly IMovimentarRobo movimentarRobo;

        public MarteController(IMovimentarRobo movimentarRobo)
        {
            this.movimentarRobo = movimentarRobo ?? throw new System.ArgumentNullException(nameof(movimentarRobo));
        }

        [HttpPost("{comando}")]
        public ActionResult<string> Movimentar(string comando)
        {
            try
            {
                return Ok(movimentarRobo.AplicarComando(comando));
            }
            catch (NegocioException nex)
            {
                return BadRequest(nex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}