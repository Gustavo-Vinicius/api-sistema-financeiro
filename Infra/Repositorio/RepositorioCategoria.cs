using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interfaces.ICategoria;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositorioGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<BaseContext> _OptionsBuilder;

        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }

        public async Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiros
                     join c in banco.Categorias on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}