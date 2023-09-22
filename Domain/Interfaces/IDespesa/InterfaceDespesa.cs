using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>>ListarDespesasUsuario(string emailUsuario); 
        Task<IList<Despesa>>ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}