using Microsoft.AspNetCore.Mvc;// Importação

namespace As.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repository; // Injeção dos repositories
        private readonly ILogger<PedidoController> _logger; 

        public PedidoController(IPedidoRepository repository, ILogger<PedidoController> logger)
        {
            _repository = repository;
            _logger = logger; // Inicializando o _logger
        }

        [HttpGet]
        public ActionResult<List<Pedido>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetById(int id)
        {
            var Pedido = _repository.GetById(id);
            if (Pedido == null)
            {
                return NotFound();
            }
            return Pedido;
        }

        [HttpPost]
        public ActionResult Post(Pedido Pedido)
        {
            // Salva o Pedido no banco de dados usando o repositório
            _repository.Post(Pedido);

            // Logando o ID do Pedido inserido
            _logger.LogInformation("Pedido inserido com ID: {PedidoId}", Pedido.Id);

            // Retorna o status 201, o local e o Pedido criado
            return CreatedAtAction(nameof(GetById), new { id = Pedido.Id }, Pedido);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Pedido PedidoAtualizado)
        {
            var PedidoEncontrado = _repository.Put(id, PedidoAtualizado);
            
            if(PedidoEncontrado == null)
                return NotFound();
            
            return Ok(PedidoEncontrado);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var PedidoEncontrado = _repository.Delete(id);
            
            if (PedidoEncontrado == null)
            {
                // Retorna 404 se o Pedido não for encontrado
                return NotFound(new { message = "Pedido não encontrado" });
            }

            // Retorna NoContent apenas se o Pedido foi realmente removido
            return NoContent();
        }

    }
}
