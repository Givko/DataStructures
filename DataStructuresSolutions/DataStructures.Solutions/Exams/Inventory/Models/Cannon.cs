namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class Cannon : Weapon
    {
        public Cannon(int id, int maxCapacity, int ammunition)
            : base(id, maxCapacity, ammunition)
        {
            Category = Category.Heavy;
        }
    }
}
