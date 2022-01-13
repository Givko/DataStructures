namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> _legion;

        public Legion()
        {
            _legion = new OrderedSet<IEnemy>();
        }

        public int Size => _legion.Count;

        public bool Contains(IEnemy enemy) => _legion.Contains(enemy);

        public void Create(IEnemy enemy) => _legion.Add(enemy);

        public IEnemy GetByAttackSpeed(int speed) => _legion.FirstOrDefault(e => e.AttackSpeed == speed);      

        public List<IEnemy> GetFaster(int speed) => _legion.Where(e => e.AttackSpeed > speed).ToList();

        public IEnemy[] GetOrderedByHealth()
        {
            var enemies = _legion.OrderByDescending(e => e.Health).ToArray();
            return enemies;
        }

        public IEnemy GetFastest()
        {
            var fastestEnemy = _legion.GetFirst();
            if (fastestEnemy == null)
                throw new InvalidOperationException("Legion has no enemies!");

            return fastestEnemy;
        }

        public List<IEnemy> GetSlower(int speed) => _legion.Where(e => e.AttackSpeed < speed).ToList();

        public IEnemy GetSlowest()
        {
            var fastestEnemy = _legion.GetLast();
            if (fastestEnemy == null)
                throw new InvalidOperationException("Legion has no enemies!");

            return fastestEnemy;
        }

        public void ShootFastest()
        {
            if (_legion.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
            var fastestEnemy = _legion.RemoveFirst();
        }

        public void ShootSlowest()
        {
            if (_legion.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var slowestEnemy = _legion.RemoveLast();
            _legion.Remove(slowestEnemy);

        }
    }
}
