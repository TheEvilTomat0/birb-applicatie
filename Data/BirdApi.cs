using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class BirdApi
    { 
        private readonly HttpClient _httpClient;

        public BirdApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ObservableCollection<BirdDTO> GetBirdList(string name)
        {
            HttpResponseMessage response = _httpClient.GetAsync("https://bird-api.codeonmedia.nl/birds?search=" + name).Result;
            ObservableCollection<BirdDTO> result = new ObservableCollection<BirdDTO>();

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ObservableCollection<BirdDTO>>(json);
            }

            return result;
        }

        public BirdDTO GetBirdData(string name)
        {
            HttpResponseMessage response = _httpClient.GetAsync("https://bird-api.codeonmedia.nl/bird/?bird=" + name).Result;
            BirdDTO bird = new BirdDTO();

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<IList<BirdDTO>>(json);
                bird = obj[0];
                bird.Img.Replace("&", "&amp;");
            }

            return bird;
        }
    }
}
