namespace DataStructures.Solutions.Exams.Inventory.Models
{
    using DataStructures.Solutions.Exams.Inventory.Interfaces;

    public abstract class Weapon : IWeapon
    {
        public Weapon(int id, int maxCapacity, int ammunition)
        {
            Id = id;
            MaxCapacity = maxCapacity;
            Ammunition = ammunition;
        }

        public int Id { get; private set; }
        public int Ammunition { get; set; }
        public int MaxCapacity { get; set; }
        public Category Category { get; set; }

        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj != null && obj is IWeapon)
            {
                return Id == ((IWeapon)obj).Id;
            }

            return false;
        }

    }
}
