namespace MinimalApi.Dominio.ModelViews
{
    public class VeiculoModelView
    {
        public int Id { get; set; }
        
        public string Marca { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public int Ano { get; set; }
    }
}