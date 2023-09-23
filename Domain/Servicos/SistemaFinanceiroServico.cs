using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.InterfaceService;
using Domain.Interfaces.ISistemaFinaceiro;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class SistemaFinanceiroServico : ISistemaFinaceiroService
    {
        private readonly InterfaceSistemaFinaceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceiroServico(InterfaceSistemaFinaceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }
        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if(valido)
            {
                var data = DateTime.Now;

                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
            }
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                sistemaFinanceiro.DiaFechamento = 1;
                await _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}