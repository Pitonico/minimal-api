using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoServicoCrudTest
{
    private DbContexto _context = null!;
    private VeiculoServico _veiculoServico = null!;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // banco novo a cada teste
            .Options;

        _context = new DbContexto(options);
        _veiculoServico = new VeiculoServico(_context);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [TestMethod]
    public void DeveCriarVeiculo()
    {
        // Arrange
        var veiculo = new Veiculo
        {
            Marca = "Toyota",
            Nome = "Hilux",
            Ano = 2020
        };

        // Act
        _veiculoServico.Incluir(veiculo);
        var lista = _veiculoServico.Todos(1);

        // Assert
        Assert.AreEqual(1, lista.Count);
        Assert.AreEqual("Hilux", lista[0].Nome);
    }

    [TestMethod]
    public void DeveBuscarPorId()
    {
        // Arrange
        var veiculo = new Veiculo
        {
            Marca = "Honda",
            Nome = "Civic",
            Ano = 2022
        };

        _veiculoServico.Incluir(veiculo);

        // Act
        var veiculoBanco = _veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.IsNotNull(veiculoBanco);
        Assert.AreEqual("Civic", veiculoBanco?.Nome);
    }

    [TestMethod]
    public void DeveAtualizarVeiculo()
    {
        // Arrange
        var veiculo = new Veiculo
        {
            Marca = "Ford",
            Nome = "Ranger",
            Ano = 2018
        };

        _veiculoServico.Incluir(veiculo);

        // Act - atualizando
        veiculo.Nome = "Ranger XLS";
        _veiculoServico.Atualizar(veiculo);

        var veiculoBanco = _veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.IsNotNull(veiculoBanco);
        Assert.AreEqual("Ranger XLS", veiculoBanco?.Nome);
    }

    [TestMethod]
    public void DeveApagarVeiculo()
    {
        // Arrange
        var veiculo = new Veiculo
        {
            Marca = "Chevrolet",
            Nome = "S10",
            Ano = 2019
        };

        _veiculoServico.Incluir(veiculo);

        // Act
        _veiculoServico.Apagar(veiculo);
        var lista = _veiculoServico.Todos(1);

        // Assert
        Assert.AreEqual(0, lista.Count);
    }

    [TestMethod]
    public void DeveListarTodosVeiculos()
    {
        // Arrange
        _veiculoServico.Incluir(new Veiculo { Marca = "Toyota", Nome = "Hilux", Ano = 2020 });
        _veiculoServico.Incluir(new Veiculo { Marca = "Honda", Nome = "Civic", Ano = 2022 });

        // Act
        var lista = _veiculoServico.Todos(1);

        // Assert
        Assert.AreEqual(2, lista.Count);
        Assert.IsTrue(lista.Any(v => v.Nome == "Hilux"));
        Assert.IsTrue(lista.Any(v => v.Nome == "Civic"));
    }
}
