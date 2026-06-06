using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalUpskill.Data.DataAccessDapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PortalUpskill.Data.DataAccessDapper.Interfaces;

namespace PortalUpskill.App.Utils
{
    public class CandidaturaBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CandidaturaBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Calcular tempo até à próxima meia noite
                var agora = DateTime.Now;
                var proximaMeiaNoite = agora.Date.AddDays(1);
                var tempoAteProximaMeiaNoite = proximaMeiaNoite - agora;

                await Task.Delay(tempoAteProximaMeiaNoite, stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var candidaturaData = scope.ServiceProvider.GetRequiredService<ICandidaturaData>();
                    var cursoData = scope.ServiceProvider.GetRequiredService<ICursoData>();

                    var cursos = cursoData.GetAll()
                        .Where(c => c.DataFimCandidatura.HasValue && c.DataFimCandidatura.Value < DateTime.Now);

                    foreach (var curso in cursos)
                    {
                        var candidatos = candidaturaData.GetAll()
                            .Where(c => c.PrimeiraOpcaoId == curso.Id &&
                                       (c.EstadoId == 1 || c.EstadoId == 2));

                        foreach (var candidato in candidatos)
                        {
                            candidaturaData.UpdateEstado(candidato.Id, 4);
                        }
                    }
                }
            }
        }
    }
    }
