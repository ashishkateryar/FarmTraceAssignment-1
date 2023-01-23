namespace FarmTrace.Data.Models
{
  public class Animal
  {
    // Id of the animal
    public int Id { get; set; }
    // Sex of the animal
    public string Sex { get; set; }
    // Type of the animal
    public string AnimalType { get; set; }
    // Record of Feedings
    public Feeding[] Feedings { get; set; }
    // Record of Milkings
    public Milking[] Milkings { get; set; }

    public Animal(int id, string sex, string animalType, Feeding[] feedings, Milking[] milkings)
    {
      Id = id;
      Sex = sex;
      AnimalType = animalType;
      Feedings = feedings;
      Milkings = milkings;
    }
  }
}
