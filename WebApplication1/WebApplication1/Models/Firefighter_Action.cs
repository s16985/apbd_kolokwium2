using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class Firefighter_Action
	{
		public int IdFirefighter { get; set; }
		public int IdAction { get; set; }


		[ForeignKey("IdFirefighter")]
		public virtual Firefighter Firefighter { get; set; }

		[ForeignKey("IdAction")]
		public virtual Action Action { get; set; }

	}
}
