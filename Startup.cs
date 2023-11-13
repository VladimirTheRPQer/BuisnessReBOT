using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace BuisnessReBOT
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration cconfiguration)
        {
            _configuration = cconfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("Db")));
            services.AddSingleton<BuisnessBot>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
