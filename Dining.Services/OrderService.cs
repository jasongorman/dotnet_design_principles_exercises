using Dining.Domain;

namespace Dining.Services;

public class OrderService {

    private Table table;
    private Menu menu;

    public OrderService(Table table, Menu menu) {
        this.table = table;
        this.menu = menu;
    }

    public void Order(string dish, int quantity) {
        Order order = table.CurrentOrder;
        MenuItem menuItem = menu.GetItem(dish);
        order.AddItem(menuItem, quantity);
    }

}