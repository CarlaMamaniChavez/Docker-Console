using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Uso: dotnet run -- <monto> <moneda_destino>");
            Console.WriteLine("Ejemplo: dotnet run -- 100 EUR");
            return;
        }

        // Leer argumentos
        decimal monto = Convert.ToDecimal(args[0]);
        string monedaDestino = args[1].ToUpper(); // EUR, BOB, etc.

        // Configurar API
        var apiKey = "tu_key"; 
        var url = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/USD";

        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;

            var tasaCambio = root
                .GetProperty("conversion_rates")
                .GetProperty(monedaDestino)
                .GetDecimal();

            decimal resultado = monto * tasaCambio;

            Console.WriteLine($" {monto} USD equivale a {resultado:F2} {monedaDestino}");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"❌ La moneda '{monedaDestino}' no es válida o no está soportada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error al consultar la API: {ex.Message}");
        }
    }
}