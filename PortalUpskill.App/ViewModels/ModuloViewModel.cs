using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{    /// <summary>
     /// Classe para validação de formulários para PortaUpskill.Data.Models.Modulo
     /// </summary>
    public class ModuloViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public double Horas { get; set; }

        [Required]
        public string Objetivos { get; set; }

        [Required]
        public string ConteudosProgramaticos { get; set; }

        [Required]
        public string SistemaAvaliacao { get; set; }

        public string Bibliografia { get; set; }

        public string SoftwareHardware { get; set; }
                

        public Modulo CreateModel()
        {
            return new Modulo
            {
                Nome = this.Nome,
                Horas = this.Horas,
                Objetivos = this.Objetivos,
                ConteudosProgramaticos = this.ConteudosProgramaticos,
                SistemaAvaliacao = this.SistemaAvaliacao,
                Bibliografia = this.Bibliografia,
                SoftwareHardware = this.SoftwareHardware
            };
        }

        public void FromModel(Modulo modulo)
        {
            Id = modulo.Id;
            Nome = modulo.Nome;
            Horas = modulo.Horas;
            Objetivos = modulo.Objetivos;
            ConteudosProgramaticos = modulo.ConteudosProgramaticos;
            SistemaAvaliacao = modulo.SistemaAvaliacao;
            Bibliografia = modulo.Bibliografia;
            SoftwareHardware = modulo.SoftwareHardware;
        }
    } 
}