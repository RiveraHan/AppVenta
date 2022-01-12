using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces
{
    public interface IDelete<TEntityID>
    {
        void Delete(TEntityID entityID);
    }
}
