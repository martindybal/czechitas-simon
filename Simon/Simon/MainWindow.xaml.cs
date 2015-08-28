using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Simon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tlacitka.Add(CerveneTlacitko);
            tlacitka.Add(ZeleneTlacitko);
            tlacitka.Add(ModreTlacitko);
            tlacitka.Add(ZluteTlacitko);
        }
        
        Random generatornahodnychCisel = new Random();
        List<Button> tlacitka = new List<Button>();

        List<Button> posloupnost = new List<Button>();
        List<Button> posloupnostNaklikana = new List<Button>();

        async void Button_ZacitHruClick(object sender, RoutedEventArgs e)
        {
            for (int x =0; x < 4; x++)
            {
                var nahodneCislo = generatornahodnychCisel.Next(0, 4);
                switch (nahodneCislo)
                {
                    case 0:
                        posloupnost.Add(CerveneTlacitko);
                        break;
                    case 1:
                        posloupnost.Add(ZeleneTlacitko);
                        break;
                    case 2:
                        posloupnost.Add(ModreTlacitko);
                        break;
                    case 3:
                        posloupnost.Add(ZluteTlacitko);
                        break;
                }
            }

            foreach (var button in posloupnost)
            {
                button.Content = "tady";

                await Task.Delay(TimeSpan.FromSeconds(1));

                button.Content = "";

                await Task.Delay(500);
            }
        }

        private void CerveneTlacitko_Click(object sender, RoutedEventArgs e)
        {
            posloupnostNaklikana.Add(CerveneTlacitko);
        }

        private void ZeleneTlacitko_Click(object sender, RoutedEventArgs e)
        {
            posloupnostNaklikana.Add(ZeleneTlacitko);
        }

        private void ModreTlacitko_Click(object sender, RoutedEventArgs e)
        {
            posloupnostNaklikana.Add(ZeleneTlacitko);
        }

        private void ZluteTlacitko_Click(object sender, RoutedEventArgs e)
        {
            posloupnostNaklikana.Add(ZluteTlacitko);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Compare())
            {
                MessageBox.Show("Vyhráls");
            }
            else
            {
                MessageBox.Show("Prohráls");
            }

            posloupnost.Clear();
            posloupnostNaklikana.Clear();
        }

        private bool Compare()
        {
            if (posloupnost.Count != posloupnostNaklikana.Count)
            {
                return false;
            }
            for (int i = 0; i < posloupnost.Count; i++)
            {
                if (posloupnost[i] != posloupnostNaklikana[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
