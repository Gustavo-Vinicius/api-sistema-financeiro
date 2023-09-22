using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interfaces.Generics;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>>ListarCategoriasUsuario(string emailUsuario);
    }
}