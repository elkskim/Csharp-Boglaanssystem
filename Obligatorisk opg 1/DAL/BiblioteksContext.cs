using Obligatorisk_opg_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opg_1.DAL
{
    public class BiblioteksContext : DbContext
    {
        public BiblioteksContext() : base("Bog")
        {

        }
        public DbSet<Bog> Boeger { get; set; }


        public DbSet<Laaner> Laanerer { get; set; }


    }
}
