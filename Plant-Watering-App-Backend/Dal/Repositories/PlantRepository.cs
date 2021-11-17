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
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return plant;
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
            _context.Entry(plant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return plant;
            
        }
    }
}
