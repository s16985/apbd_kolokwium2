using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Request;
using WebApplication1.DTOs.Response;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MyController(MyDbContext context)
        {
            _context = context;

        }

        [HttpGet("firefighters/{id}/actions")]
        public IActionResult GetFirefighterActions(int id)
        {
            Firefighter firefighter;

            try
            {
                firefighter = _context.Firefighters.Where(f => f.IdFireFighter == id).Single();
            }
            catch (Exception e)
            {
                return NotFound("Brak podanego strazaka w bazie");
            }
            ICollection<ActionResponse> actions = new List<ActionResponse>();

            var actionList = _context.Firefighter_Actions.Where(fa => fa.IdFirefighter == id).Include(fa => fa.Action).OrderByDescending(e => e.Action.EndTime).ToList();

            foreach (var i in actionList)
            {
                actions.Add(new ActionResponse
                {
                    IdAction = i.Action.IdAction,
                    StartTime = i.Action.StartTime,
                    EndTime = i.Action.EndTime
                });
            }


            return Ok(actions);
        }

        [HttpPost("actions/{id}/fire-trucks")]
        public IActionResult addTruckToAction(int id, AddTruckToActionRequest request)
        {
            if (id != request.IdAction)
            {
                return BadRequest("Niepoprawne id akcji");
            }

            FireTruck fireTruck;
            Models.Action action;

            try
            {
                fireTruck = _context.FireTrucks.Where(f => f.IdFireTruck == request.IdFireTruck).Single();
            }
            catch (Exception e)
            {
                return NotFound("Brak podanego wozu w bazie");
            }

            try
            {
                action = _context.Actions.Where(f => f.IdAction == request.IdAction).Single();
            }
            catch (Exception e)
            {
                return NotFound("Brak podanej akcji w bazie");
            }

            if(action.NeedSpecialEquipment && !fireTruck.SpecialEquipment)
            {
                return BadRequest("Wybrany woz nie posiada wymaganego wyposazenia");
            }


            if ( _context.FireTruck_Actions
                .Where(fa => fa.IdFireTruck == request.IdFireTruck)
                .Include(fa => fa.Action)
                .Where(e => e.Action.EndTime == null).Any())
            {
                return BadRequest("Wybrany woz jest zajety");
            } 


            FireTruck_Action fireTruck_Action = new FireTruck_Action
            {
                IdAction = request.IdAction,
                IdFireTruck = request.IdFireTruck,
                AssigmentDate = DateTime.Now
            };

            _context.Add(fireTruck_Action);
            _context.SaveChanges();



            return Created("" ,new FireTruckAssignment
            {
                IdFireTruck = fireTruck_Action.IdFireTruck,
                IdAction = fireTruck_Action.IdAction,
                AssigmentDate = fireTruck_Action.AssigmentDate
            }); 
        }
    }
}