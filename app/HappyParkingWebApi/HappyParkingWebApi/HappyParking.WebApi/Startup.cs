using HappyParking.Infraestructure.Data;
using HappyParking.Infraestructure.Interface;
using HappyParking.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HappyParking.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            // Add Memory Cache in App
            services.AddMemoryCache();

            // Singletions Based Connection Factory
            services.AddSingleton<IConnectionBD, ConnectionBD>(cf => new ConnectionBD(Configuration));

            services.AddDbContext<MySqlContext>(
                options => options.UseMySQL(connectionString: Configuration.GetConnectionString("ConexionMySql"),
                b => b.MigrationsAssembly(typeof(MySqlContext).Assembly.FullName)
                ));

            // Reposity Dependency Injection
            services.AddTransient<IUsuarioMySqlRepository, UsuarioMySqlRepository>();
            services.AddTransient<IPersonaMySqlRepository, PersonaMySqlRepository>();

            //Configuracion de Cors.
            //Método que permite el consumo de los servicios desde origenes externos
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

        }
    }
}
