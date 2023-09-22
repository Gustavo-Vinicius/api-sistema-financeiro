using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IUsuarioSistemaFinaceiro
{
    public interface InterfaceUsuarioSistemaFinaceiro : InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int idSistema);
        Task RemoveUsuarios (List<UsuarioSistemaFinanceiro> usuarios);
        Task <UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}