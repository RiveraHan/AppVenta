using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Application.Interfaces
{
    interface IBaseServices<TEntity, TEntityID> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IToList<TEntity, TEntityID>
    {
    }
}
