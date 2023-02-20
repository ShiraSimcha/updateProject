using Microsoft.AspNetCore.Mvc;
using cores.Models;
// using cores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace cores.Controllers
{
[ApiController]
[Route("[controller]")]
    public class TaskController : ControllerBase
    {
  
    [HttpGet]
    public IEnumerable<Assiment> Get()
    {
      return TaskServices.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Assiment> Get(int id)
    {
        var t = TaskServices.Get(id);
        if (t == null)
            return NotFound();
            return t;
    }
    
    [HttpPost]
        public ActionResult Post(Assiment assiment)
        {
            TaskServices.Add(assiment);

            return CreatedAtAction(nameof(Post), new { id = assiment.Id }, assiment);
        }
    [HttpPut("{id}")]
        public ActionResult Put(int id, Assiment assiment)
        {
            if (! TaskServices.Update(id,assiment))
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (! TaskServices.Delete(id))
                return NotFound();
            return NoContent();            
        }
 


}

}
