namespace PortalUpskill.Data.Models
{
    public class InqueritoFormador
    {
        public int Id { get; set; }
        public int InqueritoSubmissaoId { get; set; }
        public int FormadorId { get; set; }
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
    }
}