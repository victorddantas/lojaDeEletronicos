using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using mvc.Repositories;
using mvc.Repositories.Interface;
using System;

namespace mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();
            services.AddSession(); //mantém o estado entre as páginas controlado pelo setor 
            services.AddDistributedMemoryCache();//mantém as informações na memória 
            services.AddControllersWithViews();
            services.AddApplicationInsightsTelemetry();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews().AddNewtonsoftJson();

            //Definindo o serviço para configuração da conexão com o banco passando a connection string definida no appsettings.json
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<mvcContext>(options => options.UseSqlServer(connectionString));

            //aplicando a  injeção de dependência para que a instancia da classe que gera o banco seja resposabilidade do asp.net 
            services.AddTransient<IDataService,DataService>();
            services.AddTransient<IProdutoRepository,ProdutoRepository>();
            services.AddTransient<IPedidoRepository,PedidoRepository>();
            services.AddTransient<IItemPedidoRepository,ItemPedidoRepository>();
            services.AddTransient<ICadastroRepository,CadastroRepository>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();   
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pedido}/{action=Principal}/{codigo?}");
            });


            //esse serviço irá garantir que o banco será criado assim que a aplicação rodar 
            serviceProvider.GetService<IDataService>().InicializaDb();
        }
    }
}
