using System.ComponentModel.DataAnnotations;

namespace treino_mvc.DTO
{
    public class VideoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome do video é obrigátorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Link do video é obrigátorio!")]
        private string linkVideo;
        public string LinkVideo
        {
            get { return linkVideo; }
            set { linkVideo = value.Replace("watch?v=", "embed/"); }
        }
        

        [Required(ErrorMessage="Descrição do video é obrigátorio!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="Indicar o curso que essa aula pertence é obrigatório!")]
        public int CursoID { get; set; }
    }
}