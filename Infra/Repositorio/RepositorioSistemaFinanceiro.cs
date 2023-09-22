using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.ISistemaFinaceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositorioGenerics<SistemaFinanceiro>, InterfaceSistemaFinaceiro
    {
        private readonly DbContextOptions<BaseContext> _OptionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<BaseContext>();
        }
        public async Task<IList<SistemaFinanceiro>> ListarSistemaUsuario(string emailUsuario)
        {
            using (var banco = new BaseContext(_OptionsBuilder))
            {
                return await
                   (from s in banco.SistemaFinanceiros 
                    join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema                   
                    where us.EmailUsuario.Equals(emailUsuario) 
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}