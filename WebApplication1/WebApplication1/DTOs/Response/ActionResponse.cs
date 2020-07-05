using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Response
{
	public class ActionResponse
	{
		public int IdAction { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }
	}
}
