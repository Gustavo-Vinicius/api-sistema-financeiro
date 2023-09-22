using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ISistemaFinaceiro
{
    public interface InterfaceSistemaFinaceiro : InterfaceGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListarSistemaUsuario(string emailUsuario);
    }
}