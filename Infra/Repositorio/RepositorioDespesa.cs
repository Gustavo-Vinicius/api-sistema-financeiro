using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioDespesa : RepositorioGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<BaseContext> _OptionsBuilder;

        public RepositorioDespesa()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }
        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
             using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                   (from s in banco.SistemaFinanceiros
                    join c in banco.Categorias on s.Id equals c.IdSistema
                    join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema
                    join d in banco.Despesas on c.Id equals d.IdCategoria
                    where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                    select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
             using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                   (from s in banco.SistemaFinanceiros
                    join c in banco.Categorias on s.Id equals c.IdSistema
                    join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema
                    join d in banco.Despesas on c.Id equals d.IdCategoria
                    where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                    select d).AsNoTracking().ToListAsync();
            }
        }
    }
}