using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Birb.Class
{
    public class Bird
    {
        #region propfull
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        private string height;

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        private string wingSpan;

        public string WingSpan
        {
            get { return wingSpan; }
            set { wingSpan = value; }
        }

        private string img;

        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        #endregion

        //public string name { get; set; }
        //public string img { get; set; }
        //public string height { get; set; }
        //public string wingspan { get; set; }

    }
}
