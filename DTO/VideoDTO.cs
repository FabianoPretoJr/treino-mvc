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
        public string LinkVideo { get; set; }

        [Required(ErrorMessage="Descrição do video é obrigátorio!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="Indicar o curso que essa aula pertence é obrigatório!")]
        public int CursoID { get; set; }
    }
}