using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmTrace.Data.Interfaces;
using FarmTrace.Data.Models;
using FarmTrace.Data.Repository;

namespace FarmTraceAssignment.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FarmInfoController : ControllerBase
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
