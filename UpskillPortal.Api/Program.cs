using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortalUpskill.Data.DataAccessDapper;
using Serilog;
using System.Text;

namespace UpskillPortal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Debug()
                .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                // Configure JWT Authentication
                var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]!);
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // We're using HTTP so let it be false
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false, // Change to true if using issuer validation
                        ValidateAudience = false, // Change to true if using audience validation
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("CorsProfile", policy =>
                        policy.AllowAnyOrigin()
                              //.AllowCredentials(), if needed, origin needs to be specified
                              .AllowAnyHeader()
                              .AllowAnyMethod());
                });

                builder.Services.AddScoped<IAulaData, AulaData>();
                builder.Services.AddScoped<IFaltaData, FaltaData>();
                builder.Services.AddScoped<IModuloData, ModuloData>();
                builder.Services.AddScoped<ICursoData, CursoData>();
                builder.Services.AddScoped<IPessoaData, PessoaData>();
                builder.Services.AddScoped<IPessoalData, PessoalData>();
                builder.Services.AddScoped<IFormadorData, FormadorData>();
                builder.Services.AddScoped<IFormandoData, FormandoData>();
                builder.Services.AddScoped<ITurmaData, TurmaData>();
                builder.Services.AddScoped<ICNAEFData, CNAEFData>();
                builder.Services.AddScoped<IHabilitacoesData, HabilitacoesData>();
                builder.Services.AddScoped<IPaisesData, PaisesData>();
                builder.Services.AddScoped<IFuncoesData, FuncoesData>();
                builder.Services.AddScoped<ICoordenadorFormadorData, CoordenadorFormadorData>();
                builder.Services.AddScoped<IListaEstadosFormandoData, ListaEstadosFormandoData>();
                builder.Services.AddScoped<IListaEstadosFormadorData, ListaEstadosFormadorData>();
                builder.Services.AddScoped<IAvaliacaoModularData, AvaliacaoModularData>();

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BibliotecaXpto API", Version = "v1" });
                    // Add JWT Authentication to Swagger UI
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "Enter 'Bearer {your_jwt_token}'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                });

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                Log.Information("Starting up the API...");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}