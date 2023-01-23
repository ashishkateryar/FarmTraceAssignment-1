using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmTrace.Data.Models
{
  public class FarmInfo
  {
    // Name of the farm
    public string Name { get; set; }
    // Record of all animals at the farm
    public Animal[] Animals { get; set; }

    public FarmInfo(string name, Animal[] animals)
    {
      Name = name;
      Animals = animals;
    }

  }
}
