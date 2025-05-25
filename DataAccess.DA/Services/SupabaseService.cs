using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.DA;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DA.Services
{
    public class SupabaseService : ISupabaseService
    {
        private readonly SupabaseSettings _settings;
        private readonly HttpClient _httpClient;

        public SupabaseService(IConfiguration configuration)
        {
            _settings = new SupabaseSettings
            {
                Url = configuration["Supabase:Url"] ?? "",
                Key = configuration["Supabase:Key"] ?? ""
            };

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"{_settings.Url}/rest/v1/");
            _httpClient.DefaultRequestHeaders.Add("apikey", _settings.Key);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.Key);
        }

        public async Task<List<Persona>> getListPersona()
        {
            var response = await _httpClient.GetAsync("Persona?select=*");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var personas = JsonSerializer.Deserialize<List<Persona>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return personas ?? new List<Persona>();
        }
    }

    // Clase modelo para la tabla Persona
    public class Persona
    {
        public int i_id { get; set; }
        public string? v_dni { get; set; }
        public string? v_nombre { get; set; }
        public string? v_apellido_paterno { get; set; }
        public string? v_apellido_materno { get; set; }

        // Agrega aquí los demás campos según tu tabla en Supabase
    }
}
