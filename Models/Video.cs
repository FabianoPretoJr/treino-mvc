namespace treino_mvc.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        private string linkVideo;
        public string LinkVideo
        {
            get { return linkVideo; }
            set { linkVideo = value.Replace("watch?v=", "embed/"); }
        }

        public string Descricao { get; set; }

        public Curso Curso { get; set; }
    }
}