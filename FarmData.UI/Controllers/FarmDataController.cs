using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using FarmTrace.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FarmTrace.UI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FarmDataController : ControllerBase
  {
    private IFarmData _farmData = new FarmDataRepository();

    [HttpGet(Name = "GetAllFarmData")]
    public IEnumerable<FarmInfo> Get()
    {
      return _farmData.GetAllFarmData();
    }
    //[HttpGet]
    //public ActionResult<FarmInfo> GetFarmDataById(string farmName)
    //{
    //  return _farmData.GetFarmData(farmName);
    //}
  }
}
