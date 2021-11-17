using Microsoft.EntityFrameworkCore;
using Plant_Watering_App_Backend.Interfaces;
using Plant_Watering_App_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend.Dal.FakeRepositories
{
    public class FakePlantRepository : IPlantRepository
    {
        private static IQueryable<Plant> fakePlants = new List<Plant>
        {
            new Plant { id = 1, name = "Plant1", wateringPercentage = 0, lastWateredTime = null, status = Plant.WateringStatus.Idle },
            new Plant { id = 2, name = "Plant2", wateringPercentage = 0, lastWateredTime = null, status = Plant.WateringStatus.Idle },
            new Plant { id = 3, name = "Plant3", wateringPercentage = 0, lastWateredTime = null, status = Plant.WateringStatus.Idle },
            new Plant { id = 4, name = "Plant4", wateringPercentage = 0, lastWateredTime = null, status = Plant.WateringStatus.Idle },
            new Plant { id = 5, name = "Plant5", wateringPercentage = 0, lastWateredTime = null, status = Plant.WateringStatus.Idle },
        }.AsQueryable();

        

        public Task<Plant> CreatePlantAsync(Plant plant)
        {
            var newId = fakePlants.Count();
            newId++;

            var newPlant = new Plant { id = newId, lastWateredTime = null, name = plant.name, status = Plant.WateringStatus.Idle, wateringPercentage = 0 };

            fakePlants = fakePlants.Append(newPlant);
            return Task.FromResult(fakePlants.FirstOrDefault(plant => plant.id == newId));
        }

        public Task<List<Plant>> GetAllPlantsAsync()
        {
            return Task.FromResult(fakePlants.ToList());
        }

        public Task<Plant> GetPlantById(int id)
        {
            return Task.FromResult(fakePlants.FirstOrDefault(plant => plant.id == id));
        }

        public Task<Plant> UpdatePlantAsync(Plant plant)
        {
            var listPlants = fakePlants.ToList();
            var foundPlant = listPlants.FindIndex(p => p.id == plant.id);

            if (foundPlant == -1)
            {
                return Task.FromResult<Plant>(null);
            }
            listPlants[foundPlant] = plant;
            fakePlants = listPlants.AsQueryable();
            return Task.FromResult(plant);
        }
        public Task<Plant> DeletePlantAsync(int id)
        {
            var listPlants = fakePlants.ToList();
            var foundPlant = listPlants.FindIndex(p => p.id == id);

            if (foundPlant == -1)
            {
                return Task.FromResult<Plant>(null);
            }
            var plant = listPlants[foundPlant];
            listPlants.RemoveAt(foundPlant);
            fakePlants = listPlants.AsQueryable();
            return Task.FromResult(plant);
        }
    }
}
