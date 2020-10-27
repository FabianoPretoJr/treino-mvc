using System.ComponentModel.DataAnnotations;

namespace treino_mvc.DTO
{
    public class CursoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome de curso é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="descrição de curso é obrigatório!")]
        public string Descricao { get; set; }
    }
}