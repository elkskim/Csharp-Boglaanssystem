using Obligatorisk_opg_1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opg_1.DAL
{
    internal class BiblioteksInitializer : DropCreateDatabaseIfModelChanges<BiblioteksContext>
    {
        protected override void Seed(BiblioteksContext context)
        {
            context.Boeger.Add(new Bog("Alfons Aaberg", "Titlen er stavet forkert"));
            context.Boeger.Add(new Bog("Idioten", "Lang og træls, mindst 800 sider"));
            context.Boeger.Add(new Bog("Hallucinations", "Inspirationen til den der film med Robin Williams"));
            context.Boeger.Add(new Bog("Texas Hold 'Em 101", "Bluff, bluff, bluff, bluff, All in.."));

            context.Laanerer.Add(new Laaner("Polle", 23, "Pollevej 23"));
            context.Laanerer.Add(new Laaner("Lars", 20, "Larsvej 756"));
            context.Laanerer.Add(new Laaner("Karsten", 59, "Et rigtigt sted 29"));

            
           
            context.SaveChanges();
        }
    }
}
