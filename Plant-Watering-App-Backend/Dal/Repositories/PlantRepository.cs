using Microsoft.EntityFrameworkCore;
using Plant_Watering_App_Backend.Interfaces;
using Plant_Watering_App_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend.Dal.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly ApplicationDBContext _context;

        public PlantRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Plant> CreatePlantAsync(Plant plant)
        {
            var newPlant = new Plant { lastWateredTime = null, name = plant.name, status = Plant.WateringStatus.Idle, wateringPercentage = 0 };
            _context.Plants.Add(newPlant);
            await _context.SaveChangesAsync();
            return newPlant;
        }

        public async Task<Plant> DeletePlantAsync(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return null;
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return plant;
        }

        public async Task<List<Plant>> GetAllPlantsAsync()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetPlantById(int id)
        {
            return await _context.Plants.FirstOrDefaultAsync(plant => plant.id == id);
        }

        public async Task<Plant> UpdatePlantAsync(Plant plant)
        {
            var foundPlant = await GetPlantById(plant.id);
            if (foundPlant == null)
            {
                return null;
            }
            _context.Entry(foundPlant).State = EntityState.Detached;
            _context.Plants.Update(plant);
            await _context.SaveChangesAsync();
            return plant;
            
        }
    }
}
