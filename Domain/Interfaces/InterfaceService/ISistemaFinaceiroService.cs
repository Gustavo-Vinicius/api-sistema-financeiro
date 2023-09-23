using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entidades;

namespace Domain.Interfaces.InterfaceService
{
    public interface ISistemaFinaceiroService
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}