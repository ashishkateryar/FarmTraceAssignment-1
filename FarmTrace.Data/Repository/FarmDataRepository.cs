using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using Newtonsoft.Json;
using System.Linq;

namespace FarmTrace.Data.Repository
{
  public class FarmDataRepository : IFarmData
  {
    List<FarmInfo> farmList = new List<FarmInfo>();
    public FarmDataRepository()
    {
      var jsonData = JsonConvert.DeserializeObject<List<FarmInfo>>(System.IO.File.ReadAllText(@"../FarmTrace.Data/LocalFiles/farmdata.json"));

      //Run Business rules to return only valid farmData.
      farmList = RunValidationRules(jsonData);
    }

    private List<FarmInfo> RunValidationRules(List<FarmInfo> jsonData)
    {
      var validFarmList = new List<FarmInfo>();

      foreach (var item in jsonData)
      {
        var validAnimals = item.Animals.Where(animal => animal.Sex.Equals("Female") 
        && (animal.AnimalType.Equals("Cow") 
        || animal.AnimalType.Equals("Goat"))).ToList();

        foreach (var animal in validAnimals)
        {
          if (animal.AnimalType.Equals("Cow"))
          {
            var validFeedings = animal.Feedings.Where(feeding => feeding.Amount >= 0 && feeding.Amount <= 30);
            var validMilkings = animal.Milkings.Where(milking => milking.Amount >= 0 && milking.Amount <= 35);
            animal.Feedings = validFeedings.ToArray();
            animal.Milkings = validMilkings.ToArray();
          }
          else if (animal.AnimalType.Equals("Goat"))
          {
            var validFeedings = animal.Feedings.Where(feeding => feeding.Amount >= 0 && feeding.Amount <= 3);
            var validMilkings = animal.Milkings.Where(milking => milking.Amount >= 0 && milking.Amount <= 8);
            animal.Feedings = validFeedings.ToArray();
            animal.Milkings = validMilkings.ToArray();
          }
        }
        validFarmList.Add(new FarmInfo(item.Name, validAnimals.ToArray()));
      }

      return validFarmList;
    }



    public List<FarmInfo> GetAllValidFarmData()
    {
      return farmList;
    }

    public FarmInfo GetValidFarmData(string farmName)
    {
      return farmList.FirstOrDefault(x => x.Name == farmName);
    }
  }
}
