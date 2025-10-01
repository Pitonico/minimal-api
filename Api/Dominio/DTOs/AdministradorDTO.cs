
using MinimalApi.Dominio.Enuns;

namespace MinimalApi.DTOs;
public record AdministradorDTO(string Email, string Senha, Perfil? Perfil);