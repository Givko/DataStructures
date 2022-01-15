namespace DataStructures.Solutions.Exams.Inventory.Interfaces
{
    using DataStructures.Solutions.Exams.Inventory.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IWeapon
    {
        int Id { get; }

        int Ammunition { get; set; }

        int MaxCapacity { get; set; }

        Category Category { get; set; }
    }
}
