using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces.Repositories
{
    public interface IRepositoryDetail<TEntity, TMovementID>
        : IAdd<TEntity>, ITransaction
    {
    }
}
