using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoCondominialAPI.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase {
        private readonly MeuDbContext _context;

        public PagamentoController(MeuDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pagamento>> Get() {
            try {
                return _context.Pagamentos
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name = "ObterPagamento")]
        public ActionResult<Pagamento> Get(int id) {
            try {
                var pagamento = _context.Pagamentos
                    .Include(p => p.Condominio)
                    .FirstOrDefault(p => p.Id == id);

                if (pagamento == null) {
                    return NotFound($"Pagamento com id={id} não encontrado...");
                }
                return Ok(pagamento);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Pagamento pagamento) {
            try {
                if (pagamento == null)
                    return BadRequest("Dados inválidos");

                _context.Pagamentos.Add(pagamento);
                _context.SaveChanges();

                return CreatedAtRoute("ObterPagamento",
                    new { id = pagamento.Id }, pagamento);
            }
            catch (DbUpdateException dbEx) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar o banco de dados: {dbEx.Message}");
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um problema ao tratar a sua solicitação: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pagamento pagamento) {
            try {
                if (id != pagamento.Id) {
                    return BadRequest("Dados inválidos");
                }
                _context.Entry(pagamento).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(pagamento);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            try {
                var pagamento = _context.Pagamentos.FirstOrDefault(p => p.Id == id);

                if (pagamento == null) {
                    return NotFound($"Pagamento com id={id} não encontrado...");
                }
                _context.Pagamentos.Remove(pagamento);
                _context.SaveChanges();
                return Ok(pagamento);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }
    }
}
