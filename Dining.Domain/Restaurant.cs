namespace Dining.Domain;

public class Restaurant : Entity {

    private Dictionary<int, Table> tables;
    private Menu menu;

    public Restaurant(Dictionary<int, Table> tables, Menu menu) {
        this.tables = tables;
        this.menu = menu;
    }

    public Table GetTable(int tableNumber) {
        return tables[tableNumber];
    }

    public Menu Menu {
        get { return menu; }
    }

}