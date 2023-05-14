namespace Dining.Domain;

public class MenuItem : Entity {
    	
    private string name;
    private int price;

    public MenuItem(string name, int price){
        this.name = name;
        this.price = price;
    		
    }

    public int Price {
        get { return price; }
    }

    public string Name {
        get { return name; }
    }

}