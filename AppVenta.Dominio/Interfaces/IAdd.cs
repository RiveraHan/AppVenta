using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces
{
    public interface IAdd<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
