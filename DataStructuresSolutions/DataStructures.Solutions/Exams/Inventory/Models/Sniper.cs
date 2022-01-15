namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class Sniper : Weapon
    {
        public Sniper(int id, int maxCapacity, int ammunition)
             : base(id, maxCapacity, ammunition)
        {
            Category = Category.Medium;
        }
    }
}
