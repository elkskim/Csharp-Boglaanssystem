using Obligatorisk_opg_1.DAL;
using Obligatorisk_opg_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Obligatorisk_opg_1
{
    /// <summary>
    /// Interaction logic for BogDetaljer.xaml
    /// </summary>
    public partial class BogDetaljer : Window
    {
        private Bog backupBog;
        public Bog Bog { get; set; }
        public BiblioteksContext context { get; set; }

        public BogDetaljer(Bog bog, BiblioteksContext context)
        {
            Bog = bog;
            this.backupBog = bog;
            
            this.context = context;
            InitializeComponent();
            mainGrid.DataContext = Bog;
            
        }

        private void annuller(object sender, RoutedEventArgs e)
        {
            context.Boeger.Find(Bog.ID).Name = backupBog.Name;
            context.Boeger.Find(Bog.ID).Description = backupBog.Description;
            this.Close();   
        }

        private void gem(object sender, RoutedEventArgs e)
        {
            var retBog = context.Boeger.Find(Bog.ID);
            retBog.Name = NameBox.Text;
            retBog.Description = DescBox.Text;
            context.SaveChanges();

            this.Close();
        }
    }
}
