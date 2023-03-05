using mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace mvc
{
    public class mvcContext : DbContext
    {
        public mvcContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //mapeando as entidades e suas respectivas relações

            modelBuilder.Entity<Produto>().HasKey(t => t.Id); 
            
            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido); //relacionamento de um pedido contém muitos itens de pedido e um item de pedido contém em apenas 1 pedido
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired().HasForeignKey<Pedido>(t => t.Id).IsRequired(); ; //relacionamento de um pedido para um cadastro e de um cadastro pra um pedido (atributo obrigatório), definindo a chave estrangeira 
            
            
            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);//Relacionamento de um item de pedido para um pedido 
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);//Relacionamento de um item de pedido para um produto 

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido); ;//Relacionamento de um cadastro para um pedido 

        
        }
    }
}
