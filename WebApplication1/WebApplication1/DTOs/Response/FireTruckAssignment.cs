using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Response
{
	public class FireTruckAssignment
	{

		public int IdAction { get; set; }
		public int IdFireTruck { get; set; }
		public DateTime AssigmentDate { get; set; }
	}
}
