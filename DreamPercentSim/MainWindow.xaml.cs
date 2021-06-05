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

namespace DreamPercentSim
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public long Trys;
        public MainWindow()
        {
            InitializeComponent();

         }
        public void SimSim()
        {
            int dreamTrys = 262;
            double dreamSuccesses = 42;
            Random random = new Random();
            while (true)
            {
                double SuccessPearl = 0;
                for(int i = 0; i < dreamTrys; i++)
                {
                    if (random.Next(0, 10000) < 470)
                    {
                        SuccessPearl++;
                    }
                }
                if (SuccessPearl >= dreamSuccesses)
                {
                    this.console.Dispatcher.Invoke(new Action(() => 
                    { console.Text = console.Text + "\n" + System.DateTime.Now + " Worked: " + SuccessPearl + "Pearls. At Try: " + Trys; }));
                }
                //Thread saftey stuff
                long currentTrys;
                long newTrys;
                while(true)
                {
                    currentTrys = Trys;
                    newTrys = currentTrys + 1;
                    if(currentTrys == Trys)
                    {
                        Trys = newTrys;
                        break;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            console.Text = console.Text + "\n" + System.DateTime.Now + " Trys: " + Trys;
        }

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(SimSim);
                thread.Start();
            }
            console.Text = console.Text + "\n"+ System.DateTime.Now + "Simulation started";
        }
    }
}
