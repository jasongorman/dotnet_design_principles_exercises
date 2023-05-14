using Dining.Domain;
using NUnit.Framework;

namespace Dining.Services.Test;

[TestFixture]
public class BookingServiceTests {
    	
    [Test]
    public void BookingTableForFourReservedTableInSelectedSitting()  {
        Sitting sitting = Sitting.LUNCH;
        string date = "1/1/2011";
        Table table = new Table(1);
        Dictionary<int, Table> tables = new Dictionary<int, Table>();
        tables.Add(table.TableNumber, table);
        Restaurant restaurant = new Restaurant(tables, null);
        BookingService bookingService = new BookingService(restaurant);
        bookingService.BookTable(1, date, sitting);
        Assert.IsTrue(table.IsReserved(date  , sitting));
    }
    	
    [Test]
    public void UnbookedTableIsNotReservedForDateAndSitting() {
        Sitting sitting = Sitting.LUNCH;
        string date = "1/1/2011";
        Table table = new Table(1);
        Assert.IsFalse(table.IsReserved(date  , sitting));
    }

}