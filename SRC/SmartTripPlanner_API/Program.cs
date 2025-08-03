using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartTripPlanner_Infrastructure.InfrastructureDIContainer;
namespace SmartTripPlanner_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(
                options =>
                {
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                }
            )
            .AddEntityFrameworkStores<ApplicationDBContext>();
            //JWT Authentication
            string securityKey = builder.Configuration.GetSection("SecurityKey").Value;
            byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(securityKey);
            var key = new SymmetricSecurityKey(keyBytes);
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = "default";
                    options.DefaultChallengeScheme = "default";
                }
                )
            .AddJwtBearer("default", options =>
            options.TokenValidationParameters=new TokenValidationParameters{
                IssuerSigningKey=key,
                ValidateIssuer=true,
                ValidateAudience=true
            }
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
