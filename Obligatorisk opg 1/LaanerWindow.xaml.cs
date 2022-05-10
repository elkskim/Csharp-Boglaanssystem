using Obligatorisk_opg_1.DAL;
using Obligatorisk_opg_1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for LaanerWindow.xaml
    /// </summary>
    public partial class LaanerWindow : Window
    {
        public BiblioteksContext Context { get; set; }
        public LaanerWindow(BiblioteksContext context)
        {
            Context = context;
            InitializeComponent();
            
            context.Laanerer.Load();
            MainGrid.DataContext = Context;
            LaanerBox.ItemsSource = Context.Laanerer.Local;
            

            


        }

   
        private void ageFilterBtn(object sender, RoutedEventArgs e)
        {
            try 


            {
                int age = int.Parse(alderTxtBox.Text);
                LaanerBox.ItemsSource = Context.Laanerer.Local.Where(i => i.Age <= age).OrderBy(i => i.Age).ToList();
            } catch (FormatException) 

            {
                MessageBox.Show("Skriv nu en alder i feltet først.");
            }
        }

        private void resetBtn(object sender, RoutedEventArgs e)
        {
            LaanerBox.ItemsSource = from laaner in Context.Laanerer.Local
                                    orderby laaner.ID
                                    select laaner;

        }

        private void LaanerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LaanerBox.SelectedItem != null)
            {
                selectedAge.Text = ((Laaner)LaanerBox.SelectedItem).Age.ToString();
                selectedAddress.Text = ((Laaner)LaanerBox.SelectedItem).Adresse;
            } else
            {
                selectedAge.Clear();
                selectedAddress.Clear();
            }
        }

        private void orderByAddress(object sender, RoutedEventArgs e)
        {
            Context.Laanerer.Load();
            LaanerBox.ItemsSource = from laaner in Context.Laanerer.Local
                                    orderby laaner.Adresse
                                    select laaner;
        }

        private void Adresse_Selected(object sender, RoutedEventArgs e)
        {
            
            LaanerBox.ItemsSource = from laaner in Context.Laanerer.Local
                                    orderby laaner.Adresse
                                    select laaner;
        }

        private void Navn_Selected(object sender, RoutedEventArgs e)
        {
            LaanerBox.ItemsSource = Context.Laanerer.Local.OrderBy(i => i.Name);
        }

        private void ID_Selected(object sender, RoutedEventArgs e)
        {
            LaanerBox.ItemsSource = Context.Laanerer.Local.OrderBy(i => i.ID).ToList();
        }
    }
}
