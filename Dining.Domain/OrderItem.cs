namespace Dining.Domain;

public class OrderItem : Entity {

    private MenuItem menuItem;
    private int quantity;

    public OrderItem(MenuItem menuItem, int quantity) {
        this.menuItem = menuItem;
        this.quantity  = quantity;
    }

    public int SubTotal {
        get { return menuItem.Price * quantity; }
    }

}