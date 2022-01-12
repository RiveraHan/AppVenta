using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces.Repositories
{
    public interface IRepositoryMovement<TEntity, TEntityID> 
        : IAdd<TEntity>, IToList<TEntity, TEntityID>, ITransaction
    {
        void Cancel(TEntityID entityID);
    }
}
