using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityID>
        : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IToList<TEntity, TEntityID>, ITransaction
    {

    }

}
