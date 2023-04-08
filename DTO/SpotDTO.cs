using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SpotDTO
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private decimal _long;

		public decimal Long
		{
			get { return _long; }
			set { _long = value; }
		}

		private decimal lat;

		public decimal Lat
		{
			get { return lat; }
			set { lat = value; }
		}

		private DateTime date;

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

	}
}
