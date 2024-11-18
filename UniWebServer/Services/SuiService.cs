using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniWebServer.Services
{
    public class SuiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _suiNodeUrl;

        public SuiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _suiNodeUrl = configuration["SuiNodeUrl"];
        }

        public async Task<string> SendTransactionAsync(string from, string to, decimal amount)
        {
            var transactionData = new
            {
                from,
                to,
                amount
            };

            var content = new StringContent(JsonSerializer.Serialize(transactionData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_suiNodeUrl}/sendTransaction", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var transactionId = JsonSerializer.Deserialize<string>(responseContent);
            return transactionId;
        }

        public async Task<decimal> GetBalanceAsync(string address)
        {
            var response = await _httpClient.GetAsync($"{_suiNodeUrl}/getBalance?address={address}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var balance = JsonSerializer.Deserialize<decimal>(responseContent);
            return balance;
        }
    }
}
