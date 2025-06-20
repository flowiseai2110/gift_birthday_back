﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Interface.Persistence;
using Web.Api.Persistence.Context;
using Web.Data.Core;

namespace Web.Api.Persistence.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationContext _efContext;
        public EventoRepository(ApplicationContext efContext)
        {
            _efContext = efContext;
        }
        public Task<int> CreateAsync(EventoBE entity)
        {
            try { 
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _efContext.Eventos.Add(entity);
                 
                return _efContext.SaveChangesAsync().ContinueWith(task => entity.id);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw;
            }
          

        }

        public async Task<IEnumerable<EventoBE>> GetAllAsync(EventoBE entity)
        {
            return await _efContext.Eventos
               .Select(x => new EventoBE
               {
                   id = x.id,
                   nombre = x.nombre,
                   descripcion = x.descripcion,
                   fecha_inicio = x.fecha_inicio,
                   hora_inicio = x.hora_inicio,
                   fecha_fin = x.fecha_fin,
                   hora_fin = x.hora_fin, 
                   activo = x.activo 
               }).ToListAsync();
        }

        public EventoBE? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(EventoBE entity)
        {
            var existing = await _efContext.Eventos.FindAsync(entity.id);
            if (existing == null) return false;

            existing.nombre = entity.nombre;
            existing.descripcion = entity.descripcion;
            existing.fecha_inicio = entity.fecha_inicio;
            existing.fecha_fin = entity.fecha_fin;
            existing.hora_inicio = entity.hora_inicio;
            existing.hora_fin = entity.hora_fin;
            existing.fecha_modificacion = DateTime.UtcNow;
            existing.usuario_modificacion = "admin";

            await _efContext.SaveChangesAsync();

            return true;
        }
    }
}
