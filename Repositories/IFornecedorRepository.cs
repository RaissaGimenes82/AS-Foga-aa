public interface IFornecedorRepository
{
    //lista de todos os fornecedores armazenados
    public List<Fornecedor> GetAll();

    //busca um fornecedor específico com base no ID
    public Fornecedor GetById(int id);

    //adiciona um novo fornecedor ao banco de dados
    public void Post(Fornecedor Fornecedor);

    // atualiza um fornecedor existente no banco pelo ID
    public Fornecedor Put(int id, Fornecedor FornecedorAtualizado);

    //remove um fornecedor do banco pelo ID
    public Fornecedor Delete(int id);
}
