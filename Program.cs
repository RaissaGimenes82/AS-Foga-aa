using Microsoft.EntityFrameworkCore; 
using AS.Data; 
using AS.Repositories;

// Criação do objeto builder
var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Registra o contexto AppDbContext e configura a conexão com SQLite 

// Configuração  e Injeção de Dependência
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>(); 
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>(); 


// Adiciona controladores ao projeto
builder.Services.AddControllers(); 


// Adiciona o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer(); 
// Permite que a aplicação detecte os endpoints definidos
builder.Services.AddSwaggerGen(); 
// Configura o Swagger

// Construção do aplicativo web
var app = builder.Build(); 


if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseDeveloperExceptionPage(); // Exibe uma página com detalhes de erros 
    app.UseSwagger(); // Habilita o Swagger no ambiente de desenvolvimento
    app.UseSwaggerUI(); // Habilita a interface interativa do Swagger para testar os endpoints da API
}

app.UseHttpsRedirection(); // Força o uso de HTTPS para as requisições
app.UseRouting(); // Configura o roteamento das requisições para os endpoints corretos
app.UseAuthorization(); // Configura a autorização para proteger endpoints

app.MapControllers(); 
// Mapeia os controladores para seus respectivos endpoints

app.Run(); 
// Inicia a aplicação e começa a escutar as requisições
