using AutoMapper;
using LinqToDB;
using MediatR;
using System.Text.Json;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface;
using Web.Api.Interface.Persistence.GiftBirthDay;
using Web.Api.Persistence.Context;
using Web.Api.UseCases.Common.Bases;
using Web.Api.UseCases.Services.Productos;
using Web.Data.ICore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web.Api.UseCases.Services.GiftBirthDay.Queries
{
    public record class GetUsuariosQuery : IRequest<IEnumerable<UsuarioSupabaseDto>>
    { 
    }

    public class GetAllEmpresaHandler : IRequestHandler<GetUsuariosQuery, IEnumerable<UsuarioSupabaseDto>>
    {
        private readonly SupabaseContext supabase;

        public GetAllEmpresaHandler(SupabaseContext efContext)
        {
            supabase = efContext;
        }

        public async Task<IEnumerable<UsuarioSupabaseDto>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
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
