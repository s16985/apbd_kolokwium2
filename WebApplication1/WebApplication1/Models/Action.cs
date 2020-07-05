using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class Action
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdAction { get; set; }

		[Required]
		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		[Required]
		public Boolean NeedSpecialEquipment { get; set; }

		public ICollection<Firefighter_Action> Firefighter_Action { get; set; }

		public ICollection<FireTruck_Action> FireTruck_Action { get; set; }

	}
}
