using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entidades;

namespace Domain.Entidades
{

    [Table("Categoria")]
    public class Categoria : Base
    {
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}