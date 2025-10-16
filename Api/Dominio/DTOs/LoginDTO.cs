
using System.ComponentModel.DataAnnotations;

namespace MinimalApi.DTOs;
public class LoginDTO
{
  [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
  [EmailAddress(ErrorMessage = "O campo 'Email' deve conter um endereço de e-mail válido.")]
  public string Email { get; set; } = default!;
  [Required(ErrorMessage = "O campo 'Senha' é obrigatório")]
  public string Senha { get; set; } = default!;
};