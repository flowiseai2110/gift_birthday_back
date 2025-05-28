using AutoMapper;
using LinqToDB;
using MediatR;
using System.Text.Json;
using Web.Api.Domain.Entities; 
using Web.Api.Persistence.Context;

namespace Web.Api.UseCases.Services.Evento.Queries
{
    public record class GetEventAllQuery : IRequest<IEnumerable<EventoBE>>
    { 
    }

    public class GetEventAllHandler : IRequestHandler<GetEventAllQuery, IEnumerable<EventoBE>>
    {
        private readonly SupabaseContext supabase;

        public GetEventAllHandler(SupabaseContext efContext)
        {
            supabase = efContext;
        }

        public async Task<IEnumerable<EventoBE>> Handle(GetEventAllQuery request, CancellationToken cancellationToken)
        {
            var response = await supabase.httpClient().GetAsync("evento?select=*");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var usuarios = JsonSerializer.Deserialize<List<EventoBE>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return usuarios ?? new List<EventoBE>();

        }
    }
}
