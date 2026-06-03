namespace PortalUpskill.Data.Models
{
    public class InqueritoModulo
    {
        public int Id { get; set; }
        public int InqueritoSubmissaoId { get; set; }
        public int ModuloId { get; set; }
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
    }
}