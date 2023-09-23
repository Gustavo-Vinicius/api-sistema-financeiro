using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entidades;

namespace Domain.Interfaces.InterfaceService
{
    public interface IUsuarioSistemaFinaceiroService
    {
        Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}