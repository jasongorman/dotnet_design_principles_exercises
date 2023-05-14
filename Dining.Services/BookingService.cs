using Dining.Domain;

namespace Dining.Services;

public class BookingService {

    private Restaurant restaurant;

    public BookingService(Restaurant restaurant) {
        this.restaurant = restaurant;
    }

    public void BookTable(int tableNumber, string date, Sitting sitting) {
        Table table = restaurant.GetTable(tableNumber);
        table.Reserve(date, sitting);
    }

}