using MassTransit;
using Microsoft.Extensions.Configuration; 
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks; 
using Web.Api.Entidades.Core.Secciones;
using Web.Api.Helper.Excepciones;
using Web.Api.Interface;
using Web.Data.ICore; 

namespace Web.Api.UseCases.Services.Secciones
{
    public class SeccionService : ISeccionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeccionPluginManager _seccionPluginManager;
       
        private readonly IContext _context;

        public SeccionService(IUnitOfWork unitOfWork,
            ISeccionPluginManager seccionPluginManager 
           )
        {
            this._unitOfWork = unitOfWork;
            this._seccionPluginManager = seccionPluginManager;
           
            this._context = unitOfWork.Context;

        }
        public async Task<StatusResponse> Get(SeccionRequest request)
        {
            var statusResponse = new StatusResponse();

            
            string systemNameBase = "Web.Api.UseCases.Services.Secciones.Producto.ProductoImagenSeccion";
            var sectionPlugin = _seccionPluginManager.LoadPluginByName($"{systemNameBase}");

            var seccionData = new Seccion
            {
                participanteToken = request.participanteToken, 
                seccionId = 1,
                seccionOrden = 1,
                pasoOrden = 1
            };

            var seccionResponse = await sectionPlugin.Get(seccionData, null);
            if (seccionResponse.Data == null) seccionResponse.Data = new SeccionResponse();
            seccionResponse.Data.seccionId = 1;
            return seccionResponse;
        }

        public async Task<StatusResponse> Save(SeccionSaveRequest request)
        {
            var response = new StatusResponse();
            string systemNameBase = "Web.Api.UseCases.Services.Secciones.Producto.ProductoImagenSeccion";
            var sectionPlugin = _seccionPluginManager.LoadPluginByName($"{systemNameBase}");
             
            var seccionData = new Seccion
            {
                participanteToken = request.participanteToken,
                seccionId = 1,
                seccionOrden = 1,
                pasoOrden = 1,
                body = request.requestBody
            };
            var seccionResponse = await sectionPlugin.Save(seccionData, null);

            var commit = await _unitOfWork.CommitAsync(true) > 0;
            if (commit) {
                response.Success = true;
                response.Messages.Add("guardado correctamente.");
            }
            else
            {
                response.Success = false;
                response.Messages.Add("Ups.. hubo un error.");
            }
            return seccionResponse;

            
        }
    }
}
