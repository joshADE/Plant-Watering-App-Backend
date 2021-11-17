using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_Watering_App_Backend.Dal;
using Plant_Watering_App_Backend.Interfaces;
using Plant_Watering_App_Backend.Models;

namespace Plant_Watering_App_Backend.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {

        private readonly IPlantRepository _plants;

        public PlantsController(IPlantRepository plants)
        {
            _plants = plants;
        }

        // GET: api/Plants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
        {
            return Ok(await _plants.GetAllPlantsAsync());
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _plants.GetPlantById(id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        // PUT: api/Plants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(int id, Plant plant)
        {
            if (id != plant.id)
            {
                return BadRequest();
            }
            try
            {
                plant = await _plants.UpdatePlantAsync(plant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        // POST: api/Plants
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {

            plant = await _plants.CreatePlantAsync(plant);

            return CreatedAtAction("GetPlant", new { id = plant.id }, plant);
        }

        // DELETE: api/Plants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plant>> DeletePlant(int id)
        {
            Plant result =  await _plants.DeletePlantAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
            
        }

        private bool PlantExists(int id)
        {
            return _plants.GetPlantById(id) != null;
        }
    }
}
