using Domain.Interfaces.InterfaceService;
using Domain.Interfaces.IUsuarioSistemaFinaceiro;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinaceiroService
    {
         private readonly InterfaceUsuarioSistemaFinaceiro _interfaceUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServico(InterfaceUsuarioSistemaFinaceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }
        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _interfaceUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}