namespace LoginApp.Models
{
    public class Chamado
    {
        public string Usuario { get; set; }
        public string Equipamento { get; set; }
        public DateTime DataHoraAgendada { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public string Endereco { get; set; }
    }
}
