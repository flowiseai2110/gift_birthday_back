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
    public record SaveCommand:IRequest<bool>
    {
       public required ProductoDto dataDto { get; set; }
    }
    public sealed class SaveCommandHandler : IRequestHandler<SaveCommand, bool>
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   
        private readonly IContext _context;

        public SaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = _unitOfWork.Context;
            _mapper = mapper;   
        }

        public async Task<bool> Handle(SaveCommand request, CancellationToken cancellationToken)    
        {   
            try
            { 
                var entity = await _context.Query<Producto>(false).FirstOrDefaultAsync(x => x.productoId == request.dataDto.productoId && x.activo);

                if (entity == null)
                {
                    entity = _mapper.Map<Producto>(request.dataDto);
                    entity.fechaRegistro = DateTime.Now;
                    
                    _context.Add(entity);
                }
                else {
                    _mapper.Map(request.dataDto, entity);
                    entity.fechaModificacion = DateTime.Now;
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
