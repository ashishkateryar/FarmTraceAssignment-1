using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmTrace.Data.Models
{
  public class Milking
  {
    // Date and time of milking
    public DateTime DateTime { get; set; }
    // Amount of milk in kg
    public int Amount { get; set; }

    // Constructor
    public Milking(DateTime dateTime, int amount)
    {
      DateTime = dateTime;
      Amount = amount;
    }    
  }
}
