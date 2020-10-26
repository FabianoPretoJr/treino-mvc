namespace treino_mvc.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string LinkVideo { get; set; }

        public string Descricao { get; set; }

        public Curso Curso { get; set; }
    }
}