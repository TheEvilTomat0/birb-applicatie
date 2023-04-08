using Domain;
using Data;
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
using DTO;

namespace Birb.Views
{
    /// <summary>
    /// Interaction logic for BirdInfo.xaml
    /// </summary>
    public partial class BirdInfo : Page, INotifyPropertyChanged
    {
        public string SelectedBird { get; set; }

        private string birdName;

        public string BirdName
        {
            get { return birdName; }
            set { birdName = value; OnPropertyChanged("BirdName"); FillBirdList(); }
        }

        public BirdDomain BirdDomain { get; set; }

        private ObservableCollection<BirdDTO> birds;

        public ObservableCollection<BirdDTO> Birds
        {
            get { return birds; }
            set { birds = value; OnPropertyChanged(); }
        }

        private BirdDTO singleBird;

        public BirdDTO SingleBird
        {
            get { return singleBird; }
            set { singleBird = value; OnPropertyChanged(); }
        }


        public BirdInfo()
        {
            InitializeComponent();
            DataContext = this;
            BirdDomain = new BirdDomain();
        }

        public void FillBirdList()
        {
            Birds = BirdDomain.GetBirdList(BirdName);            
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
                SingleBird = BirdDomain.GetBirdData(SelectedBird);
            }
        }
    }
}
