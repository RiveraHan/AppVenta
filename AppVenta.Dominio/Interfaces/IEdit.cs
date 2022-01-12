using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces
{
    public interface IEdit<TEntity>
    {
        void Edit(TEntity entity);
    }
}
