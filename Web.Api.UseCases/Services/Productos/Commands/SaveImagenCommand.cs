using AutoMapper;
using LinqToDB;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Services.Productos;
using Web.Api.Domain.Enums;
using Web.Api.Interface; 
using Web.Data.ICore;
using Web.Api.Domain.Entities;
using static LinqToDB.Common.Configuration;

namespace Web.Api.UseCases.Services.Productos.Commands
{
    public record SaveImagenCommand : IRequest<bool>
    {
       public required ProductoImagenDto dataDto { get; set; }
    }
    public sealed class SaveImagenCommandHandler : IRequestHandler<SaveImagenCommand, bool>
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   
        private readonly IContext _context;

        public SaveImagenCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = _unitOfWork.Context;
            _mapper = mapper;   
        }

        public async Task<bool> Handle(SaveImagenCommand request, CancellationToken cancellationToken)    
        {   
            try
            { 
                var entity = await _context.Query<ProductoImagen>(false).FirstOrDefaultAsync(x => x.productoImagenId == request.dataDto.productoImagenId && x.activo);

                if (entity == null)
                {
                    entity = _mapper.Map<ProductoImagen>(request.dataDto);
                    
                    _context.Add(entity);
                }
                else {
                    _mapper.Map(request.dataDto, entity);
                    
                }
                 
                return true;  

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
