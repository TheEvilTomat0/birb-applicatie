using Birb.Class;
using Birb.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Birb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void getData(string letter)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5000/bird?bird=" + letter);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var bird = response.Content.ReadAsAsync<IEnumerable<Bird>>().Result;
            //    dg.ItemsSource = bird;
            //}
            //else
            //{
            //    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            //}
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            StackPanel stackPanel = (StackPanel)radioButton.Content;
            TextBlock text = (TextBlock)stackPanel.Children[1];
            Console.WriteLine(text.Text);

            if (text.Text == "Dashboard")
            {
                Frame.Content = new Dashboard();
            }
            else if(text.Text == "Bird info")
            {
                Frame.Content = new BirdInfo();
            } 
            else if(text.Text == "Account")
            {
                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
