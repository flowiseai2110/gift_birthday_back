 
using Microsoft.Extensions.Configuration; 
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Web.Api.Persistence.Context
{
    public class SupabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public string SupabaseUrl { get; }
        public string SupabaseKey { get; }

        public SupabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            SupabaseUrl = _configuration["Supabase:Url"] ?? string.Empty;
            SupabaseKey = _configuration["Supabase:Key"] ?? string.Empty;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{SupabaseUrl}/rest/v1/");
            _httpClient.DefaultRequestHeaders.Add("apikey", SupabaseKey);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SupabaseKey);

        }

        public HttpClient httpClient() {
            return _httpClient;
        }

    }
}
