using AS.Data;

namespace AS.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Fornecedor Delete(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id); // Verifica se o fornecedor existe no banco

            if (fornecedor == null)
            {
                // Retorna null se o fornecedor não for encontrado
                return null;
            }

            // Remove o fornecedor da base de dados
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges(); // Salva as alterações

            return fornecedor; // Retorna o fornecedor removido
        }


        public List<Fornecedor> GetAll()
        {
            return _context.Fornecedores.ToList();
        }

        public Fornecedor GetById(int id)
        {
            return _context.Fornecedores.Find(id);
        }

        public void Post(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
        }

        public Fornecedor Put(int id, Fornecedor fornecedorAtualizado)
        {
            // Procura no banco de dados o fornecedor correspondente ao ID fornecido
            var fornecedor = _context.Fornecedores.Find(id); 

            // Verifica se o fornecedor foi encontrado no banco
            if (fornecedor == null)
                return fornecedor; // Retorna null caso o fornecedor não exista

            // Atualiza os campos do fornecedor com os valores 
            fornecedor.Nome = fornecedorAtualizado.Nome; 
            fornecedor.CNPJ = fornecedorAtualizado.CNPJ; 
            fornecedor.Telefone = fornecedorAtualizado.Telefone; 
            fornecedor.Email = fornecedorAtualizado.Email;
            fornecedor.Endereco = fornecedorAtualizado.Endereco; 

            // Salva as alterações no banco de dados
            _context.SaveChanges();

            // Retorna o fornecedor atualizado
            return fornecedor;
        }

    }
}
