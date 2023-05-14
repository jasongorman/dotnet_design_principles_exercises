namespace Dining.Domain;

public class Table : Entity {

    private int tableNumber;
    	
    private Dictionary<string, Dictionary<Sitting, Reservation>> reservedDates = new Dictionary<string, Dictionary<Sitting, Reservation>>();

    private Order currentOrder = new Order();
    	
    public Table(int tableNumber) {
        this.tableNumber = tableNumber;
    }
    	
    public void Reserve(string date, Sitting sitting){
        Dictionary<Sitting, Reservation> reservedSittings = new Dictionary<Sitting, Reservation>();
        reservedSittings.Add(sitting, new Reservation());
        reservedDates.Add(date, reservedSittings);
    }

    public bool IsReserved(string date, Sitting sitting) {
        Dictionary<Sitting, Reservation> reservedSittings = null;
        if(reservedDates.ContainsKey(date))
            reservedSittings = reservedDates[date];
        if(reservedSittings != null){
            return reservedSittings.ContainsKey(sitting);
        }
        return false;
    }

    public int TableNumber {
        get { return tableNumber; }
    }

    public int CurrentOrderTotal {
        get { return currentOrder.Total; }
    }

    public Order CurrentOrder {
        get { return currentOrder; }
    }

}