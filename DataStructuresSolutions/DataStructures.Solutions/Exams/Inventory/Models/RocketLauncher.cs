namespace DataStructures.Solutions.Exams.Inventory.Models
{
    public class RocketLauncher : Weapon
    {
        public RocketLauncher(int id, int maxCapacity, int ammunition)
            : base(id, maxCapacity, ammunition)
        {
            Category = Category.Heavy;
        }
    }
}
