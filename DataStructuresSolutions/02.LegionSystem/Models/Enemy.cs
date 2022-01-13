﻿namespace _02.LegionSystem.Models
{
    using System;
    using _02.LegionSystem.Interfaces;

    public class Enemy : IEnemy
    {
        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(IEnemy obj)
        {
            if (obj != null)
            {
                if (AttackSpeed > ((IEnemy)obj).AttackSpeed)
                    return -1;
                else if (AttackSpeed == ((IEnemy)obj).AttackSpeed)
                    return 0;
                else
                    return 1;
            }

            throw new ArgumentNullException(nameof(obj));
        }

        public override bool Equals(object obj)
        {      
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj != null && obj is IEnemy)
            {
                return AttackSpeed == ((IEnemy)obj).AttackSpeed;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AttackSpeed);
        }
    }
}
