
using System.Linq.Expressions;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Reflection;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;
using Dominio.Interface;
using Persistence.Data;
using Persistencia.Data;
namespace Application.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly PdfDemoContext _context;
    public BaseRepository(PdfDemoContext context){
        _context = context;
    } 
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

      public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> paginacion (int pageIndex, int pageSize, string _search)
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

}
