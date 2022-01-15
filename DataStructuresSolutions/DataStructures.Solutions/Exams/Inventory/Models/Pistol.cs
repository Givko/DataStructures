namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class Pistol : Weapon
    {
        public Pistol(int id, int maxCapacity, int ammunition)
          : base(id, maxCapacity, ammunition)
        {
            Category = Category.Light;
        }
    }
}
