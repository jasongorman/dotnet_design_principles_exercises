namespace Dining.Domain;

public class Order : Entity {
    	
    private IList<OrderItem> orderItems = new List<OrderItem>();

    public void AddItem(MenuItem menuItem, int quantity) {
        orderItems.Add(new OrderItem(menuItem, quantity));
    }

    public int Total {
        get {
            int total = 0;
            foreach (OrderItem orderItem in orderItems){
                total += orderItem.SubTotal;
            }
            return total;
        }
    }

}