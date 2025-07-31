using AutoMapper; //To use MapperConfiguration.
using MappingObjects.Mappers;
using Northwind.EntityModels;
using Northwind.ViewModels; //To use CartToSummaryMapper.
namespace MappingObjects.Tests;

public class TestAutoMapperConfig
{
    [Fact]
    public void TestSummaryMapping()
    {
        MapperConfiguration config = CartToSummaryMapper.
            GetMapperConfiguration();
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void TestSummaryContent()
    {
        //Arrange
        var customer = new Customer("Bruno", "Souza");
        var listItem = new List<LineItem>
        {
            new(ProductName: "Computer", UnitPrice: 300.5M, Quantity: 5),
            new(ProductName: "TV", UnitPrice: 150.5M, Quantity: 10)
        };

        //Act
        var cart = new Cart(customer, listItem);
        
        var config = CartToSummaryMapper.GetMapperConfiguration();
        IMapper mapper = config.CreateMapper();
        Summary summary = mapper.Map<Cart, Summary>(cart);

        //Assert
        Assert.Equal("Bruno Souza", summary.FullName);
        Assert.Equal(3007.5M, summary.Total);
    }
}