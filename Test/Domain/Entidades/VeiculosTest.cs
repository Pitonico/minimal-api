using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo
        {
        // Act
            Id = 1,
            Marca = "Toyota",
            Nome = "Hilux",
            Ano = 2020
        };
        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Toyota", veiculo.Marca);
        Assert.AreEqual("Hilux", veiculo.Nome);
        Assert.AreEqual(2020, veiculo.Ano);
    }
}