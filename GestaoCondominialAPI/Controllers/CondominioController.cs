using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoCondominialAPI.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase {
        private readonly MeuDbContext _context;

        public CondominioController(MeuDbContext context) {
            _context = context;
        }

        [HttpGet("moradores")]
        public ActionResult<IEnumerable<Condominio>> GetCondominiosMoradores() {
            try {
                var condominios = _context.Condominios
                    .Include(c => c.Moradores)
                    .Include(c => c.Pagamentos)
                    .AsNoTracking()
                    .ToList();

                return Ok(condominios);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Condominio>> Get() {
            try {
                var condominios = _context.Condominios
                    .AsNoTracking()
                    .ToList();

                return Ok(condominios);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCondominio")]
        public ActionResult<Condominio> Get(int id) {
            try {
                var condominio = _context.Condominios
                    .Include(c => c.Moradores)
                    .Include(c => c.Pagamentos)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);

                if (condominio == null) {
                    return NotFound($"Condomínio com id={id} não encontrado...");
                }
                return Ok(condominio);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post(Condominio condominio) {
            try {
                if (condominio == null)
                    return BadRequest("Dados inválidos");

                _context.Condominios.Add(condominio);
                _context.SaveChanges();

                return CreatedAtRoute("ObterCondominio",
                    new { id = condominio.Id }, condominio);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Condominio condominio) {
            try {
                if (id != condominio.Id) {
                    return BadRequest("Dados inválidos");
                }

                var existingCondominio = _context.Condominios
                    .FirstOrDefault(c => c.Id == id);

                if (existingCondominio == null) {
                    return NotFound($"Condomínio com id={id} não encontrado...");
                }

                _context.Entry(existingCondominio).CurrentValues.SetValues(condominio);
                _context.SaveChanges();

                return Ok(condominio);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            try {
                var condominio = _context.Condominios
                    .FirstOrDefault(c => c.Id == id);

                if (condominio == null) {
                    return NotFound($"Condomínio com id={id} não encontrado...");
                }

                _context.Condominios.Remove(condominio);
                _context.SaveChanges();

                return Ok(condominio);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }
    }
}
