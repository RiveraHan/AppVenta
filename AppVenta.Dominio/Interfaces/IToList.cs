using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces
{
    public interface IToList<TEntity, TEntityID>
    {
        List<TEntity> ToList();

        TEntity SelectForId(TEntityID entityID);
    }
}
