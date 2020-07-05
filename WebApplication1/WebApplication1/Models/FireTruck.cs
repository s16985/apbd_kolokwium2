using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class FireTruck
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdFireTruck { get; set; }

		[Required]
		[MaxLength(10)]
		public string OperationalNumber { get; set; }

		[Required]
		public Boolean SpecialEquipment { get; set; }


		public ICollection<FireTruck_Action> FireTruck_Action { get; set; }

	}
}
