using Microsoft.EntityFrameworkCore; 

namespace AS.Data
{
    
    public class AppDbContext : DbContext
    {
        // Construtor e conexao com o banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // mapeia a tabela "Pedidos" no banco de dados
        public DbSet<Pedido> Pedidos { get; set; } = default!; 

        // mapeia a tabela "Fornecedores" no banco de dados
        public DbSet<Fornecedor> Fornecedores { get; set; } = default!;

        // Método que é chamado ao criar o modelo de dados para o banco
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            
        }
    }
}
