 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface.Persistence;
using Web.Api.Interface.Persistence.Promocion;

namespace Web.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmpresaRepository Empresa { get; }
        public ILocalComercialRepository LocalComercial { get; }
        public IUsuarioRepository Usuario { get; }
        public ICartillaRepository Cartilla { get; }
        //public ICartillaPromocionRepository CartillaPromocion { get; }
        //public IClienteCartillaDetalleRepository ClienteCartillaDetalle { get; }
        //public IClienteCartillaRepository ClienteCartilla { get; }
        public IClienteRepository Cliente { get; }
        public ICPromocionRepository Promocion { get; } 
        public IProductoRepository Productos { get; }
        public UnitOfWork(
            IEmpresaRepository empresa, 
            IProductoRepository productos,
            ILocalComercialRepository localComercial,
            IUsuarioRepository usuarioRepository,
            ICPromocionRepository cpromocion,
            ICartillaRepository cartilla,
            IClienteRepository cliente)
        {
            Empresa = empresa;
            Productos = productos;
            LocalComercial = localComercial;
            Usuario = usuarioRepository;
            Promocion = cpromocion;
            Cartilla = cartilla;
            Cliente = cliente;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
