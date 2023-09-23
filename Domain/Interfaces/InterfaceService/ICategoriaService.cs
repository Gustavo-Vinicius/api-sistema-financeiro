using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Interfaces.InterfaceService
{
    public interface ICategoriaService
    {
        Task AdicionarCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
    }
}