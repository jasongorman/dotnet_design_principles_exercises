using Moq;

namespace GuitarShack.Test;

public class StockMonitorIntegrationTests
{
    [Test]
    public void WhenStockReachesReorderLevelAlertIsSent()
    {
        var alert = new Mock<IReorderAlert>();
        StockMonitor monitor = new StockMonitor(alert.Object);
        Task task = monitor.OnSale(811, 50);
        task.Wait();
        alert.Verify(x => x.Send(It.IsAny<Product>()));
    }
    
    [Test]
    public void WhenStockRemainsAboveReorderLevelAlertIsNotSent()
    {
        var alert = new Mock<IReorderAlert>();
        StockMonitor monitor = new StockMonitor(alert.Object);
        Task task = monitor.OnSale(811, 1);
        task.Wait();
        alert.Verify(x => x.Send(It.IsAny<Product>()), Times.Never);
    }
}