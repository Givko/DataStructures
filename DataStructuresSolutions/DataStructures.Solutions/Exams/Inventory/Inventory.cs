namespace DataStructures.Solutions.Exams.Inventory
{
    using DataStructures.Solutions.Exams.Inventory.Interfaces;
    using DataStructures.Solutions.Exams.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        List<IWeapon> _weapons;

        public Inventory()
        {
            _weapons = new List<IWeapon>();
        }

        public int Capacity => _weapons.Count;

        public void Add(IWeapon weapon) => _weapons.Add(weapon);

        public void Clear() => _weapons.Clear();

        public bool Contains(IWeapon weapon) => _weapons.Contains(weapon);

        public void EmptyArsenal(Category category) => _weapons.ForEach(w => w.Ammunition = 0);

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var weaponToFire = GetById(weapon.Id);
            if (weaponToFire == null)
                throw new InvalidOperationException("Weapon does not exist in inventory!");

            if (weaponToFire.Ammunition < ammunition)
                return false;

            weaponToFire.Ammunition -= ammunition;
            return true;
        }

        public IWeapon GetById(int id) => _weapons.Find(w => w.Id == id);

        public IEnumerator GetEnumerator() => _weapons.GetEnumerator();

        public int Refill(IWeapon weapon, int ammunition)
        {
            var weaponToRefill = GetById(weapon.Id);
            if (weaponToRefill == null)
                throw new InvalidOperationException("Weapon does not exist in inventory!");

            if (weaponToRefill.Ammunition + ammunition > weaponToRefill.MaxCapacity)
            {
                weaponToRefill.Ammunition = weaponToRefill.MaxCapacity;
                return weaponToRefill.MaxCapacity;
            }

            weaponToRefill.Ammunition += ammunition;
            return weaponToRefill.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            int index = _weapons.FindIndex(w => w.Id == id);
            if (index == -1)
                throw new InvalidOperationException("Weapon does not exist in inventory!");

            var weaponToRemove = _weapons[index];
            _weapons.RemoveAt(index);

            return weaponToRemove;
        }

        public int RemoveHeavy()
        {
            int removedCount = _weapons.RemoveAll(w => w.Category == Category.Heavy);

            return removedCount;
        }

        public List<IWeapon> RetrieveAll() => new List<IWeapon>(_weapons);

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        => _weapons.Where(w => w.Category >= lower && w.Category <= upper).ToList();


        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var firstWeaponToSwapIndex = _weapons.FindIndex(w => w.Id == firstWeapon.Id);
            if (firstWeaponToSwapIndex == -1)
                throw new InvalidOperationException("Weapon does not exist in inventory!");

            var secondWeaponToSwapIndex = _weapons.FindIndex(w => w.Id == secondWeapon.Id);
            if (secondWeaponToSwapIndex == -1)
                throw new InvalidOperationException("Weapon does not exist in inventory!");

            if (_weapons[firstWeaponToSwapIndex].Category != _weapons[secondWeaponToSwapIndex].Category)
                return;

            IWeapon temp = _weapons[firstWeaponToSwapIndex];
            _weapons[firstWeaponToSwapIndex] = _weapons[secondWeaponToSwapIndex];
            _weapons[secondWeaponToSwapIndex] = temp;
        }
    }
}
