using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace ExchangeConsoleApp
{
    // --- MODELE DANYCH ---
    public class ExchangeRatesRoot
    {
        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;
        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; } = new();
    }

    public class ExchangeDate
    {
        public int Id { get; set; } // Klucz główny
        public required string DateString { get; set; }
        public string? Base { get; set; }

        public List<CurrencyRate> Rates { get; set; } = new();
    }

    public class CurrencyRate
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public double Rate { get; set; }

        public int ExchangeDateId { get; set; } // Klucz obcy
        public ExchangeDate ExchangeDate { get; set; } = null!;
    }

    // --- KONTEKST BAZY (DbContext) ---
    internal class ExchangeDbContext : DbContext // Klasa wewnętrzna
    {
        public DbSet<ExchangeDate> ExchangeDates { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=exchange_history.db");
        }
    }

    public class CurrencyService
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string AppId = "23c7228897f84480add9177256722b28";

        public async Task GetAndProcessData(string date)
        {
            using var db = new ExchangeDbContext();
            db.Database.EnsureCreated(); // Tworzy bazę jeśli jej nie ma

            var cached = db.ExchangeDates.Include(d => d.Rates)
                           .FirstOrDefault(d => d.DateString == date);

            if (cached != null)
            {
                Console.WriteLine($"\n[BAZA] Dane dla {date} już są. Nie pobieram z API.");
                foreach (var r in cached.Rates.Take(5))
                    Console.WriteLine($"{r.Code}: {r.Rate}");
                return;
            }

            Console.WriteLine($"\n[API] Pobieranie danych dla {date}...");
            string url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={AppId}";

            try
            {
                var response = await _client.GetFromJsonAsync<ExchangeRatesRoot>(url);
                if (response != null)
                {
                    var newEntry = new ExchangeDate
                    {
                        DateString = date,
                        Base = response.Base,
                        Rates = response.Rates.Select(r => new CurrencyRate { Code = r.Key, Rate = r.Value }).ToList()
                    };

                    db.ExchangeDates.Add(newEntry);
                    db.SaveChanges(); 
                    Console.WriteLine("Pomyślnie zapisano do bazy.");
                }
            }
            catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var service = new CurrencyService();
            Console.Write("Podaj datę (RRRR-MM-DD): ");
            string date = Console.ReadLine() ?? "2024-01-01";

            await service.GetAndProcessData(date);
            Console.ReadKey();
        }
    }
}