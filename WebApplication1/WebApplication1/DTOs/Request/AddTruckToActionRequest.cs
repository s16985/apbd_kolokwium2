﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Request
{
	public class AddTruckToActionRequest
	{
		public int IdAction { get; set; }
		public int IdFireTruck { get; set; }

	}
}
