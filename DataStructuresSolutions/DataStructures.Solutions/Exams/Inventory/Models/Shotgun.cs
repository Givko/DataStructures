namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class Shotgun : Weapon
    {
        public Shotgun(int id, int maxCapacity, int ammunition)
          : base(id, maxCapacity, ammunition)
        {
            Category = Category.Light;
        }
    }
}
