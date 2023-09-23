using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entidades;

namespace Domain.Interfaces.InterfaceService
{
    public interface IDespesaService
    {
        Task AdicionarDespesa(Despesa despesa);
        Task AtualizarDepesa(Despesa despesa);
    }
}