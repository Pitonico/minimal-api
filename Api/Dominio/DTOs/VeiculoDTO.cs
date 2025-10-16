
using System.ComponentModel.DataAnnotations;

namespace MinimalApi.DTOs;

public class VeiculoDTO
{

    [Required(ErrorMessage = "A marca é obrigatória")]
    [StringLength(100, ErrorMessage = "A marca deve ter no máximo 100 caracteres")]
    public string Marca { get; set; } = default!;
    [Required(ErrorMessage = "O modelo é obrigatório")]
    [StringLength(150, ErrorMessage = "O modelo deve ter no máximo 150 caracteres")]
    public string Modelo { get; set; } = default!;
    
    [Required(ErrorMessage = "O ano é obrigatório")]
    [Range(1950, int.MaxValue, ErrorMessage = "O ano deve estar acima de 1950")]
    public int Ano { get; set; }
  }