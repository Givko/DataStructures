namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class Minigun : Weapon
    {
        public Minigun(int id, int maxCapacity, int ammunition)
            : base(id, maxCapacity, ammunition)
        {
            Category = Category.Medium;
        }
    }
}
