using FarmTrace.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmTrace.Data.Interfaces
{
  public interface IFarmData
  {
    List<FarmInfo> GetAllValidFarmData();
    FarmInfo GetValidFarmData(string farmName);
  }
}
