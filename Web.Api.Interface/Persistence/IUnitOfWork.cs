using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface.Persistence.Promocion;

namespace Web.Api.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEmpresaRepository Empresa { get;}
        ILocalComercialRepository LocalComercial { get;}
        IUsuarioRepository Usuario { get; }
        ICartillaRepository Cartilla { get; }
        //ICartillaPromocionRepository CartillaPromocion { get; }
        IClienteRepository Cliente { get; }
        //IClienteCartillaRepository ClienteCartilla { get; }
        //IClienteCartillaDetalleRepository ClienteCartillaDetalle { get; }
        ICPromocionRepository Promocion { get; }
        IProductoRepository Productos { get; }
    }
}
