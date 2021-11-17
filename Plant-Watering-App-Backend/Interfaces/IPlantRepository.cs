using Plant_Watering_App_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend.Interfaces
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant> GetPlantById(int id);
        Task<Plant> CreatePlantAsync(Plant plant);
        Task<Plant> UpdatePlantAsync(Plant plant);
        Task<Plant> DeletePlantAsync(int id);


    }
}
