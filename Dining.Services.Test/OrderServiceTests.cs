using Dining.Domain;
using NUnit.Framework;

namespace Dining.Services.Test;

[TestFixture]
public class OrderServiceTests {
    	
    [Test]
    public void AddingItemToCoverAddsMenuItemPriceTimesQuantityToTotal(){
        Table table = new Table(1);
        Menu menu = new Menu();
        menu.AddDish("Steak & Chips", 10);
        OrderService orderService = new OrderService(table, menu);
        orderService.Order("Steak & Chips", 3);
        Assert.AreEqual(30, table.CurrentOrderTotal);
    }

}