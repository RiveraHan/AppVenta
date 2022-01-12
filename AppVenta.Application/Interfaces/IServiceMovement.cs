using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Application.Interfaces
{
    interface IServiceMovement<TEntity, TEntityID> : IAdd<TEntity>, IToList<TEntity, TEntityID>
    {
        void Cancel(TEntityID entityID);
    }
}
