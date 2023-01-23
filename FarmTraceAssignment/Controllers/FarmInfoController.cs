using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using FarmTrace.Data.Repository;

namespace FarmTraceAssignment.Controllers
{
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class FarmInfoController : ControllerBase
  {
    private IFarmData _farmData = new FarmDataRepository();

    [HttpGet(Name = "GetAllFarmData")]
    public IEnumerable<FarmInfo> Get()
    {
      return _farmData.GetAllValidFarmData();
    }
    [HttpGet(Name = "GetFarmDataById")]
    public FarmInfo GetFarmDataById(string farmName)
    {
      return _farmData.GetValidFarmData(farmName);
    }
  }
}
