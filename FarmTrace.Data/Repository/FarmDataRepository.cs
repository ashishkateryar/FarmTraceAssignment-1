using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using Newtonsoft.Json;

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
      var validFarmList = jsonData.Where
        (
          x => x.Animals.Any(
            // Female Animals
            y => y.Sex.Equals("Female"))
            // If Cow, Feedings are limited to 0 to 30 and Milkings are limited to 0 to 35
            && x.Animals.Any(y => y.AnimalType.Equals("Cow") && y.Feedings.Any(z => z.Amount >= 0 && z.Amount <= 30) && y.Milkings.Any(z => z.Amount >= 0 && z.Amount <= 35))
            // If Goat, Feedings are limited to 0 to 3 and Milkings are limited to 0 to 8
            && x.Animals.Any(y => y.AnimalType.Equals("Goat") && y.Feedings.Any(z => z.Amount >= 0 && z.Amount <= 3) && y.Milkings.Any(z => z.Amount >= 0 && z.Amount <= 8))
      ).ToList();
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
