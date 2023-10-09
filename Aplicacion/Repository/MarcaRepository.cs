using Dominio.Entities;
using Dominio.Interface;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;

public class MarcaRepository : BaseRepository<Marca>, IMarca
{
    public MarcaRepository(PdfDemoContext context) : base(context)
    {
    }
    
}
