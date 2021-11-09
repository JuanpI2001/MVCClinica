using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCClinica.Models;
using System.Data.Entity;

namespace MVCClinica.Data
{
    public class MedicoDbContext:DbContext
    {
        public MedicoDbContext() : base("KeyDB") { }
        public DbSet<Medico> Medicos { get; set; }
    }
}