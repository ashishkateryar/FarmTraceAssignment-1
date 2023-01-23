using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmTrace.Data.Models
{
  public class Feeding
  {
    // Date and time of feeding
    public DateTime DateTime { get; set; }
    // Amount of feed in kg
    public int Amount { get; set; }

    //Constructor
    public Feeding(DateTime dateTime, int amount)
    {
      DateTime = dateTime;
      Amount = amount;
    }
  }  
}
