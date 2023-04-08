using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BirdDomain
    {
        public ObservableCollection<BirdDTO> GetBirdList(string name)
        {
            try
            {
                BirdApi birdApi = new BirdApi(new HttpClient());
                return birdApi.GetBirdList(name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BirdDTO GetBirdData(string name)
        {
            try
            {
                BirdApi birdApi = new BirdApi(new HttpClient());
                return birdApi.GetBirdData(name);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
