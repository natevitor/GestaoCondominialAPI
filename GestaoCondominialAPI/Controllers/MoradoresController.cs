using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoCondominialAPI.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase {
        private readonly MeuDbContext _context;

        public MoradorController(MeuDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Morador>> Get() {
            try {
                return _context.Moradores
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name = "ObterMorador")]
        public ActionResult<Morador> Get(int id) {
            try {
                var morador = _context.Moradores
                    .Include(m => m.Condominio)
                    .FirstOrDefault(m => m.Id == id);

                if (morador == null) {
                    return NotFound($"Morador com id={id} não encontrado...");
                }
                return Ok(morador);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Morador morador) {
            try {
                if (morador == null)
                    return BadRequest("Dados inválidos");

                _context.Moradores.Add(morador);
                _context.SaveChanges();

                return CreatedAtRoute("ObterMorador",
                    new { id = morador.Id }, morador);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Morador morador) {
            try {
                if (id != morador.Id) {
                    return BadRequest("Dados inválidos");
                }
                _context.Entry(morador).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(morador);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            try {
                var morador = _context.Moradores.FirstOrDefault(m => m.Id == id);

                if (morador == null) {
                    return NotFound($"Morador com id={id} não encontrado...");
                }
                _context.Moradores.Remove(morador);
                _context.SaveChanges();
                return Ok(morador);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }
    }
}
