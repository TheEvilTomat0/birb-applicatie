using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BirdDTO
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string height;

		public string Height
		{
			get { return height; }
			set { height = value; }
		}

		private string wingspan;

		public string Wingspan
		{
			get { return wingspan; }
			set { wingspan = value; }
		}

		private string img;

		public string Img
		{
			get { return img; }
			set { img = value; }
		}
	}
}
