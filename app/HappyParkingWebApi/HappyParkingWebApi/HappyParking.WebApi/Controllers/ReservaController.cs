using HappyParking.Entity;
using HappyParking.Infraestructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HappyParking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly IUsuarioMySqlRepository _usuarioMySqlRepository;

        public ReservaController(IUsuarioMySqlRepository usuarioMySqlRepository)
        {
            _usuarioMySqlRepository = usuarioMySqlRepository ?? throw new ArgumentNullException(nameof(usuarioMySqlRepository));
        }
        [HttpPost]
        public async Task<ActionResult> Insertar([FromBody] UsuarioInsertarRequest usuarioInsertarRequest)
        {
            try
            {
                var result = await _usuarioMySqlRepository.Insertar(UsuarioInsertarRequest.UsuarioInsertarRequestToUsuario(usuarioInsertarRequest));
                return Ok(UsuarioInsertarResponse.UsuarioToUsuarioInsertarResponse(result));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message.ToString());
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(Int64 id, [FromBody] UsuarioActualizarRequest usuarioActualizarRequest)
        {
            try
            {
                var usuario = UsuarioActualizarRequest.UsuarioActualizarRequestToUsuario(usuarioActualizarRequest);
                usuario.IdUsuario = id;

                var result = await _usuarioMySqlRepository.Actualizar(usuario);
                return Ok(UsuarioResponse.UsuarioToUsuarioResponse(result));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Int64 id, [FromBody] UsuarioEliminarRequest usuarioEliminarRequest)
        {
            try
            {
                var usuario = UsuarioEliminarRequest.UsuarioEliminarRequestToUsuario(usuarioEliminarRequest);
                usuario.IdUsuario = id;

                var result = await _usuarioMySqlRepository.Eliminar(usuario);
                return Ok(UsuarioResponse.UsuarioToUsuarioResponse(result));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message.ToString());
            }
        }
        [Route("ObtenerPorConcepto")]
        [HttpPost]
        public async Task<ActionResult> ObtenerPorConcepto([FromBody] UsuarioObtenerPorConceptoRequest usuarioObtenerPorConceptoRequest)
        {
            try
            {
                var usuarioList = await _usuarioMySqlRepository.ObtenerPorConcepto(UsuarioObtenerPorConceptoRequest.UsuarioObtenerPorConceptoRequestToUsuario(usuarioObtenerPorConceptoRequest));

                return Ok(usuarioList.Select(selector: UsuarioObtenerPorConceptoResponse.ProyeccionDto()).ToList());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerPorPropiedad(Int64 id)
        {
            try
            {
                var result = await _usuarioMySqlRepository.ObtenerPorPropiedad(new Usuario { IdUsuario = id, Filtros = new ComunRequest(), Retorno = new RetornoResponse() });
                return Ok(UsuarioObtenerPorPropiedadResponse.UsuarioToUsuarioObtenerPorConceptoResponse(result));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message.ToString());
            }
        }
    }
}
