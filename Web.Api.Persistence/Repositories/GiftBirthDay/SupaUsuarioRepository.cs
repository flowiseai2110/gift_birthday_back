using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence.GiftBirthDay;
using Web.Api.Persistence.Context;
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Persistence.Repositories.GiftBirthDay
{
    public class SupaUsuarioRepository : ISupaUsuarioRepository
    {
        private readonly SupabaseContext supabase;
        

        public SupaUsuarioRepository(SupabaseContext efContext)
        {
            supabase = efContext;
        }

        public Task<int> CreateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public bool UpdateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Usuario>> GetAllAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario? GetByIdAsync(int id)
        { 
            throw new NotImplementedException();
        } 
        public async Task<IEnumerable<UsuarioSupabaseDto>> GetUsuario()
        {
            var response = await supabase.httpClient().GetAsync("Persona?select=*");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var usuarios = JsonSerializer.Deserialize<List<UsuarioSupabaseDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return usuarios ?? new List<UsuarioSupabaseDto>();
        }
    }
}
