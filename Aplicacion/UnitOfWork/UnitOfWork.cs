using Application.Repository;
using Dominio.Interface;
using Persistence.Data;
using Persistencia.Data;
namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ProductoRepository _productos;
    private MarcaRepository _marca;
    private readonly PdfDemoContext _context;
    public UnitOfWork(PdfDemoContext context){
        _context = context;
    }
    public IProducto Productos{get{
        if(_productos == null){
            _productos = new ProductoRepository(_context);
        }
        return _productos;
    }}
    public IMarca Marca {
        get{
            _marca ??= new MarcaRepository(_context);
            return _marca;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
