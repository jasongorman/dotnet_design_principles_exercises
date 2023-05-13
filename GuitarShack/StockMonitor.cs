using System.Net.Http.Headers;
using System.Text.Json;

namespace GuitarShack
{
    public class StockMonitor
    {
        private readonly IReorderAlert _alert;

        public StockMonitor(IReorderAlert alert)
        {
            _alert = alert;
        }

        public async Task OnSale(int productId, int quantity)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            var productTask = client.GetStreamAsync("https://6hr1390c1j.execute-api.us-east-2.amazonaws.com/default/product?id=" + productId);
            var product = await JsonSerializer.DeserializeAsync<Product>(await productTask);

            var endDate = DateTime.Now;
            var formattedEndDate = endDate.ToString("M/d/yyyy");
            var startDate = endDate.AddDays(-30);
            var formattedStartDate = startDate.ToString("M/d/yyyy");
            
            var salesTask =
                client.GetStreamAsync(
                    $"https://gjtvhjg8e9.execute-api.us-east-2.amazonaws.com/default/sales?productId={productId}&startDate={formattedStartDate}&endDate={formattedEndDate}&action=total");
            var sales = await JsonSerializer.DeserializeAsync<Sales>(await salesTask);

            if (product.stock - quantity <= Math.Ceiling(product.leadTime * ((double)sales.total / 30)))
            {
                _alert.Send(product);
            }
        }
            
    }
}