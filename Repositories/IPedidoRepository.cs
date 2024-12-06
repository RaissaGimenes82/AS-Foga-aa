
public interface IPedidoRepository
{
    public List<Pedido> GetAll();

    public Pedido GetById (int id);

    public void Post (Pedido Pedido);

    public Pedido Put (int id, Pedido PedidoAtualizado);

    public Pedido Delete (int id);
}