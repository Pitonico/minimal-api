using System.ComponentModel.DataAnnotations;
using MinimalApi.Dominio.Enuns;

namespace MinimalApi.Dominio.DTOs
{
    public class AdministradorDTO
    {
        [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo 'Email' deve conter um endereço de e-mail válido.")]
        [StringLength(255, ErrorMessage = "O campo 'Email' deve ter no máximo 255 caracteres.")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "O campo 'Senha' é obrigatório")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "O campo 'Senha' deve ter entre 8 e 50 caracteres.")]
        public string Senha { get; set; } = default!;
        [Required(ErrorMessage = "O campo 'Perfil' é obrigatório")]
        [EnumDataType(typeof(Perfil), ErrorMessage = "O campo 'Perfil' deve conter um valor válido.")]
        public Perfil? Perfil { get; set; }
    }
}