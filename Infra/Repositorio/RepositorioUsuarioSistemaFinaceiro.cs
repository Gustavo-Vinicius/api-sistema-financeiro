using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.IUsuarioSistemaFinaceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinaceiro : RepositorioGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinaceiro
    {
        private readonly DbContextOptions<BaseContext> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinaceiro()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int idSistema)
        {
            using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiros
                    .Where(s => s.IdSistema == idSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiros.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new BaseContext(_OptionsBuilder))
            {
                banco.UsuarioSistemaFinanceiros
               .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}