using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interface;
    public interface IUnitOfWork
    {
    IProducto Productos {get;}
    IMarca Marca {get;}
    }
