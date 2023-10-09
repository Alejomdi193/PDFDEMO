
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

public class ProductoRepository : BaseRepository<Producto>, IProducto
{
    private readonly PdfDemoContext _context;
    public ProductoRepository(PdfDemoContext context) : base(context)
    {
        _context = context;
    }
      public override async Task<(int totalRegistros, IEnumerable<Producto> registros)> paginacion (int pageIndex, int pageSize, string _search)
    {
        var totalRegistros = await _context.Set<Producto>().CountAsync();
        var registros = await _context.Set<Producto>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Include(e => e.Marca)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
