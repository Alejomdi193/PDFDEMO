using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class Marca : BaseEntity
    {
        
        public string Descripcion { get; set; }
        public ICollection<Producto> Productos {get; set; }

    }
