using AS.Data;

namespace AS.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Pedido Delete(int id)
        {
            var Pedido = _context.Pedidos.Find(id); // Verifica se o Pedido existe no banco

            if (Pedido == null)
            {
                // Retorna null se o Pedido não for encontrado
                return null;
            }

            // Remove o Pedido da base de dados
            _context.Pedidos.Remove(Pedido);
            _context.SaveChanges(); // Salva as alterações

            return Pedido; // Retorna o Pedido removido
        }


        public List<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public void Post(Pedido Pedido)
        {
            _context.Pedidos.Add(Pedido);
            _context.SaveChanges();
        }

        public Pedido Put(int id, Pedido PedidoAtualizado)
        {
            var Pedido = _context.Pedidos.Find(id);
            if (Pedido == null)
                return Pedido;

            Pedido.Id = PedidoAtualizado.Id;
            Pedido.Data = PedidoAtualizado.Data;
            Pedido.ValorTotal = PedidoAtualizado.ValorTotal;
            Pedido.Status = PedidoAtualizado.Status;
            Pedido.Descricao = PedidoAtualizado.Descricao;

            _context.SaveChanges();
            return Pedido;
        }
    }
}
