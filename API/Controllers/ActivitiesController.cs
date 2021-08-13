using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new Application.Activities.List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivities(Guid id)
        {
            return await Mediator.Send(new Application.Activities.Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivitiy(Activity activity)
        {
            return Ok(await Mediator.Send(new Application.Activities.Create.Command { Activity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivitiy(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Application.Activities.Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivitiy(Guid id)
        {
            return Ok(await Mediator.Send(new Application.Activities.Delete.Command { Id = id }));
        }
    }
}
