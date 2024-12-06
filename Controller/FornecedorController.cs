using Microsoft.AspNetCore.Mvc; // Importação da biblioteca 

namespace As.Controllers
{
    [ApiController] // Indica que esta classe é um controlador de API
    [Route("[controller]")] // Define a base da rota para este controlador
    public class FornecedorController : ControllerBase
    {
        // Dependências injetadas via construtor
        private readonly IFornecedorRepository _repository; // Interface para o repositório de fornecedores
        private readonly ILogger<FornecedorController> _logger; // mensagens de erro ou sucesso.

        // Construtor do controlador
        public FornecedorController(IFornecedorRepository repository, ILogger<FornecedorController> logger)
        {
            _repository = repository; // Inicia o repositório de fornecedores.
            _logger = logger; // Inicializa o logger.
        }

        // GET: /fornecedor
        [HttpGet] 
        public ActionResult<List<Fornecedor>> GetAll()
        {
            // Chama o GetAll de todos os fornecedores
            return Ok(_repository.GetAll());
        }

        // GET: /fornecedor/{id}
        [HttpGet("{id}")] 
        public ActionResult<Fornecedor> GetById(int id)
        {
            // Busca o fornecedor pelo ID usando o repositório.
            var fornecedor = _repository.GetById(id);

            if (fornecedor == null)
            {
                // Se o fornecedor não for encontrado, retorna um  HTTP 404
                return NotFound();
            }

            // Se encontrado, retorna o fornecedor 200 OK.
            return fornecedor;
        }

        // POST: /fornecedor
        [HttpPost] // cria um novo fornecedor
        public ActionResult Post(Fornecedor fornecedor)
        {
            // Salva o novo fornecedor 
            _repository.Post(fornecedor);

            // Registra no log que o fornecedor foi inserido com sucesso, incluindo seu ID.
            _logger.LogInformation("Fornecedor inserido com ID: {FornecedorId}", fornecedor.Id);

            // Retorna um 201, junto com a URL e o objeto fornecedor.
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }
        
        // PUT: /fornecedor/{id}
        [HttpPut("{id}")] // Rota PUT que atualiza um fornecedor
        public ActionResult Put(int id, Fornecedor FornecedorAtualizado)
        {
            // atualiza o fornecedor no repositório.
            var FornecedorEncontrado = _repository.Put(id, FornecedorAtualizado);
            
            if (FornecedorEncontrado == null)
            {
                // Se o fornecedor não for encontrado, retorna 404 
                return NotFound();
            }
            
            // Se encontrado e atualizado, retorna 200 OK
            return Ok(FornecedorEncontrado);
        }

        // DELETE: /fornecedor/{id}
        [HttpDelete("{id}")] // Rota delete, que remove um fornecedor pelo ID
        public ActionResult Delete(int id)
        {
            // Tenta remover o fornecedor do repositório pelo ID.
            var fornecedorEncontrado = _repository.Delete(id);
            
            if (fornecedorEncontrado == null)
            {
                // Se o fornecedor não for encontrado, retorna  404
                return NotFound(new { message = "Fornecedor não encontrado" });
            }

            // Se o fornecedor foi removido com sucesso, retorna 204 
            return NoContent();
        }

    }
}
