using Birb.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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

namespace Birb.Views
{
    /// <summary>
    /// Interaction logic for BirdInfo.xaml
    /// </summary>
    public partial class BirdInfo : Page, INotifyPropertyChanged
    {
        private string birdName;

        public string BirdName
        {
            get { return birdName; }
            set { birdName = value; OnPropertyChanged("BirdName"); getBirdList(); }
        }

        public string SelectedBird { get; set; }

        private ObservableCollection<Bird> birds;

        public ObservableCollection<Bird> Birds
        {
            get { return birds; }
            set { birds = value; OnPropertyChanged("Birds"); }
        }

        private Bird bird;

        public Bird Bird
        {
            get { return bird; }
            set { bird = value; OnPropertyChanged("Bird"); }
        }


        public BirdInfo()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void getBirdList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://bird-api.codeonmedia.nl/birds/?search=" + BirdName);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                Birds = response.Content.ReadAsAsync<ObservableCollection<Bird>>().Result;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            SelectedBird = listBox.SelectedValue.ToString();

            if (SelectedBird != null)
            {
                getBirdData();
            }
        }

        private void getBirdData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://bird-api.codeonmedia.nl/bird/?bird=" + SelectedBird);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                //object bird = response.Content.ReadAsAsync<ObservableCollection<Bird>>().Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<IList<Bird>>(json);
                Bird = obj[0];
                Bird.Img.Replace("&", "&amp;");
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

            #region TestCode
            //using (var client = new HttpClient())
            //{
            //    var endpoint = "https://bird-api.codeonmedia.nl/bird/?bird=" + SelectedBird;
            //    var result = client.GetAsync(endpoint).Result;
            //    //var json = JsonConvert.SerializeObject(result);
            //    var json = result.Content.ReadAsStringAsync().Result;
            //    var obj = JsonConvert.DeserializeObject<IList<Bird>>(json);
            //    Bird = obj[0];
            //}
            #endregion
        }


    }
}
