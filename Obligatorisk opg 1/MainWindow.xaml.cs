using Obligatorisk_opg_1.DAL;
using Obligatorisk_opg_1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Obligatorisk_opg_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BiblioteksContext context = new BiblioteksContext();
        public MainWindow()
        {
            
            InitializeComponent();

            
            context.Boeger.Load();

            context.Laanerer.Load();
            LaanerBox.ItemsSource = context.Laanerer.Local;

            mainGrid.DataContext = context.Boeger.Local;
            BogBox.ItemsSource = context.Boeger.Local;

            BogBox.Items.Refresh();


            //BeggeBox nægter at starte tom. Nu tvinger vi den.
            BeggeBox.ItemsSource = new List<Bog>();

            

            
            

            context.SaveChanges();
        }

        private void BeggeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            BeggeBox.ItemsSource = context.Laanerer.Find(((Laaner)LaanerBox.SelectedItem).ID).bogList; 
           
        }

        private void TilfoejBog(object sender, RoutedEventArgs e)
        {
            
            if (((Bog)BogBox.SelectedItem) == null)
            {
                MessageBox.Show("Der er ikke valgt en bog i oversigten over bøger");
            }

            else if (((Laaner)LaanerBox.SelectedItem) == null)
            {
                MessageBox.Show("Der er ikke valgt en låner at tilføje bogen til.");
            }
            else if (((Bog)BogBox.SelectedItem).Laaner == null)
            {
                ((Laaner)LaanerBox.SelectedItem).bogList.Add((Bog)BogBox.SelectedItem);
                context.SaveChanges();
                
            } 
            else 
            { 
                MessageBox.Show("Bogen er allerede udlånt."); 
            }

            
            BogBox.Items.Refresh();
            BeggeBox.Items.Refresh();

            
            
        }

        private void FjernBog(object sender, RoutedEventArgs e)
        {

            
            if (((Bog)BeggeBox.SelectedItem) == null)
            {
                MessageBox.Show("Der er ikke valgt en bog i oversigten over låners bøger.");
            }
            else if (((Bog)BeggeBox.SelectedItem).Laaner != null)
            {
                ((Laaner)LaanerBox.SelectedItem).bogList.Remove(((Bog)BeggeBox.SelectedItem));



                context.SaveChanges();

            }
            
            else
            {
                MessageBox.Show("Bogen er ikke endnu udlånt.");
            }
 
            
            BeggeBox.Items.Refresh();
            BogBox.Items.Refresh();


        }

        private void DetaljeBtn(object sender, RoutedEventArgs e)
        {
            if (((Bog)BogBox.SelectedItem) != null) {
                var BogDet = new BogDetaljer(((Bog)BogBox.SelectedItem), context);
                BogDet.Owner = this;
                BogDet.ShowDialog();
                context.SaveChanges();
                BogBox.Items.Refresh();
                BeggeBox.Items.Refresh();
              


            } else
            {
                MessageBox.Show("Der skal vælges en bog at se detaljer på, før der kan vises detaljer for en bog.");
            }

        }
            private void LaanerWindowBtn(object sender, RoutedEventArgs e)
            {
                var newLaanerWindow = new LaanerWindow(context);
                newLaanerWindow.Owner = this;
                newLaanerWindow.ShowDialog();

            }
       

        

        
    }
}
