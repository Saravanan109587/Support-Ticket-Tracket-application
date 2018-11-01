using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketTrackerAPI.HUBS;

namespace TicketTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoFacTestController : Controller
    {
        private readonly ITicketNotifier _ticketnotifier;
        public AutoFacTestController(ITicketNotifier ticketnotifier)
        {
            _ticketnotifier = ticketnotifier;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {

            _ticketnotifier.SendMessage("test");
            return "";
        }
    }
}