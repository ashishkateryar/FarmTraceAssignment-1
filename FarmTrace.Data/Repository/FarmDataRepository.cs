using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace FarmTrace.Data.Repository
{
  public class FarmDataRepository : IFarmData
  {
    List<FarmInfo> farmList = new List<FarmInfo>();
    public FarmDataRepository()
    {
      farmList = JsonConvert.DeserializeObject<List<FarmInfo>>(System.IO.File.ReadAllText(@"../FarmTrace.Data/LocalFiles/farmdata.json"));
    }

    public List<FarmInfo> GetAllFarmData()
    {
      return farmList;
    }

    public FarmInfo GetFarmData(string farmName)
    {      
      return farmList.FirstOrDefault(x => x.Name == farmName);
    }
  }
}
