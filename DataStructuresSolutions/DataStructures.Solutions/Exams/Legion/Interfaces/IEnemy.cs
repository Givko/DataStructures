namespace DataStructures.Solutions.Exams.Legion.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEnemy : IComparable<IEnemy>
    {
        int AttackSpeed { get; set; }

        int Health { get; set; }
    }
}
