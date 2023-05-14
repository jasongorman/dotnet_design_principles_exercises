namespace Dining.Domain;

public class Menu : Entity {

    private Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>();

    public void AddDish(string name, int price) {
        menuItems.Add(name, new MenuItem(name, price));
    		
    }

    public MenuItem GetItem(string dish) {
        return menuItems[dish];
    }

}