using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceService;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class DespesaServico : IDespesaService
    {
        private readonly InterfaceDespesa _InterfaceDespesa;
        public DespesaServico(InterfaceDespesa InterfaceDespesa)
        {
            _InterfaceDespesa = InterfaceDespesa;
        }
        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _InterfaceDespesa.Add(despesa);

        }

        public async Task AtualizarDepesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _InterfaceDespesa.Update(despesa);
        }
    }
}