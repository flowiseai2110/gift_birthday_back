using AutoMapper;
using LinqToDB;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Enums;
using Web.Api.Dto.Services.Productos;
using Web.Api.Interface;
using Web.Api.Interface.Persistence;
using Web.Api.Persistence.Context;
using Web.Data.ICore;
using static LinqToDB.Common.Configuration;

namespace Web.Api.UseCases.Services.Evento.Commands
{
    public class SaveEventCommand:IRequest<bool>
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int categoria_id { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string hora_inicio { get; set; } = string.Empty;
        public string hora_fin { get; set; } = string.Empty;
        public int estado { get; set; }
    }
    public class SaveCommandHandler : IRequestHandler<SaveEventCommand, bool>
    {

        private readonly IEventoRepository client;

        public SaveCommandHandler(IEventoRepository efContext)
        {
            client = efContext;
        }

        public async Task<bool> Handle(SaveEventCommand request, CancellationToken cancellationToken)    
        {   
            try
            { 
                var entity = new EventoBE
                {
                    id = request.id,
                    nombre = request.nombre,
                    descripcion = request.descripcion,
                    //categoriaId = request.categoria_id,
                    fecha_inicio = request.fecha_inicio,
                    fecha_fin = request.fecha_inicio,
                    hora_inicio = TimeSpan.Parse(request.hora_inicio),
                    hora_fin = TimeSpan.Parse(request.hora_fin),
                    fecha_registro = DateTime.UtcNow,
                    usuario_registro = "admin" // o request.user, si lo tienes

                };
                 
                int result = await client.CreateAsync(entity);

                return result > 0 ? true : false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
