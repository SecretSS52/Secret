using Magaz.Models;
using Magaz.Sklad;
using Magaz.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Magaz.Tests;

[TestClass]
public class OrderCalculatorTests
{
    private readonly OrderCalculator _calculator = new OrderCalculator();


    [TestMethod]
    public void Order_GameCategory_ReturnsTotalWithOnePercentDiscount()
    {
        var product = new Product("Cyberpunk 2077", Category.Game, 1000);
        decimal result = _calculator.Order(product, quantity: 1);
        Assert.AreEqual(700, result); // 1000 - 30% = 700
    }

    [TestMethod]
    public void Order_FoodCategory_ReturnsTotalWithTwoPercentDiscount()
    {
        var product = new Product("Молоко", Category.Food, 2000);
        decimal result = _calculator.Order(product, quantity: 1);
        Assert.AreEqual(1960, result); // 2000 - 2% = 1960
    }

    [TestMethod]
    public void Order_FishCategory_ReturnsTotalWithThreePercentDiscount()
    {
        var product = new Product("Сёмга", Category.Fish, 3000);
        decimal result = _calculator.Order(product, quantity: 1);
        Assert.AreEqual(2910, result); // 3000 - 3% = 2910
    }

    [TestMethod]
    public void Order_WithQuantity_AppliesDiscountToTotalSum()
    {
        var product = new Product("Настолка", Category.Game, 500m);
        decimal result = _calculator.Order(product, quantity: 4);
        Assert.AreEqual(1980m, result); // (500 * 4) - 1% = 1980
    }



    [TestMethod]
    public void Order_Collection_ReturnsSumOfDiscountedPrices()
    {
        var products = new List<Product>
        {
            new Product(" ", Category.Game, 1000m), // 1000 - 1% = 990
            new Product("", Category.Food, 500m),   // 500 - 2% = 490
            new Product("Рыба", Category.Fish, 100m)   // 100 - 3% = 97
        };

        decimal result = _calculator.Order(products);
        Assert.AreEqual(1577m, result); // 990 + 490 + 97
    }


    [TestMethod]
    public void CatyghoryTavar_Game_ReturnsOne()
    {
        Assert.AreEqual(1m, _calculator.CatyghoryTavar(Category.Game));
    }

    [TestMethod]
    public void CatyghoryTavar_Food_ReturnsTwo()
    {
        Assert.AreEqual(2m, _calculator.CatyghoryTavar(Category.Food));
    }

    [TestMethod]
    public void CatyghoryTavar_Fish_ReturnsThree()
    {
        Assert.AreEqual(3m, _calculator.CatyghoryTavar(Category.Fish));
    }


    [TestMethod]
    public void Product_WithValidData_CreatedSuccessfully()
    {
        var product = new Product("Валидный товар", Category.Game, 100m);
        Assert.IsNotNull(product);
        Assert.AreEqual("Валидный товар", product.Name);
        Assert.AreEqual(100m, product.Price);
    }

    [TestMethod]
    public void Product_EmptyName_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Product("", Category.Game, 100m));
    }

    [TestMethod]
    public void Product_WhitespaceName_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Product("   ", Category.Game, 100m));
    }

    [TestMethod]
    public void Product_ZeroPrice_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Product("Тест", Category.Game, 0m));
    }

    [TestMethod]
    public void Product_NegativePrice_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Product("Тест", Category.Game, -50m));
    }

}