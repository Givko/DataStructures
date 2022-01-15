namespace DataStructures.Solutions.Tests.Exams
{
    using DataStructures.Solutions.Exams.Inventory;
    using DataStructures.Solutions.Exams.Inventory.Interfaces;
    using DataStructures.Solutions.Exams.Inventory.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class InventoryTests
    {
        private IHolder _inventory;
        private IWeapon _savedWeapon;

        [SetUp]
        public void SetupInventory()
        {
            _inventory = new Inventory();
            ConstructorInfo[] constructors = new ConstructorInfo[]
            {
                GetConstructorInfo(typeof(Pistol)),
                GetConstructorInfo(typeof(Shotgun)),
                GetConstructorInfo(typeof(Minigun)),
                GetConstructorInfo(typeof(Sniper)),
                GetConstructorInfo(typeof(RocketLauncher)),
                GetConstructorInfo(typeof(Cannon)),
            };
            Random rnd = new Random();
            int boundIndex = rnd.Next(20);

            for (int i = 0; i < 20; i++)
            {
                var rndConstructor = constructors[rnd.Next(constructors.Length)];
                var rndAmmunition = rnd.Next(500);
                var rndMaxCapacity = rndAmmunition + rnd.Next(100);
                IWeapon rndWeapon = (IWeapon)rndConstructor
                    .Invoke(new object[] { i, rndMaxCapacity, rndAmmunition });
                if (i == boundIndex)
                {
                    _savedWeapon = rndWeapon;
                }

                _inventory.Add(rndWeapon);
            }
        }

        private ConstructorInfo GetConstructorInfo(Type eType)
        {
            return eType.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int) });
        }

        [Test]
        public void CapacityWorksCorrectly()
        {
            Assert.AreEqual(20, _inventory.Capacity);
        }

        [Test]
        public void AddWorksCorrectly()
        {
            _inventory.Add(new Sniper(21, 200, 50));
            Assert.AreEqual(21, _inventory.Capacity);
        }

        [Test]
        public void GetByIdWorksCorrectly()
        {
            IWeapon weaponById = _inventory.GetById(_savedWeapon.Id);

            Assert.AreEqual(_savedWeapon, weaponById);
        }


        [Test]
        public void ContainsFindsEntity()
        {
            Assert.IsTrue(_inventory.Contains(_savedWeapon));
        }


        [Test]
        public void RefillAmmunitionWorksCorrectly()
        {
            int ammoToRefill = _savedWeapon.MaxCapacity - _savedWeapon.Ammunition;
            int expectedAmmo = _savedWeapon.MaxCapacity;

            _inventory.Refill(_savedWeapon, ammoToRefill);

            Assert.AreEqual(expectedAmmo, _savedWeapon.Ammunition);
        }

        [Test]
        public void FireWorksCorrectly()
        {
            Random rnd = new Random();
            int ammoToFire = rnd.Next(_savedWeapon.Ammunition);
            int expectedAmmo = _savedWeapon.Ammunition - ammoToFire;

            bool isPossible = _inventory.Fire(_savedWeapon, ammoToFire);

            Assert.IsTrue(isPossible);
            Assert.AreEqual(expectedAmmo, _savedWeapon.Ammunition);
        }

        [Test]
        public void RemoveByIdWorksCorrectly()
        {
            var expectedCapacity = 19;

            IWeapon removed = _inventory.RemoveById(_savedWeapon.Id);

            Assert.AreEqual(expectedCapacity, _inventory.Capacity);
            Assert.AreEqual(_savedWeapon, removed);
        }

        [Test]
        public void SwapWorksCorrectly()
        {
            IWeapon freshWeapon = null;

            switch (_savedWeapon.Category)
            {
                case Category.Light:
                    freshWeapon = new Pistol(21, 500, 400);
                    break;
                case Category.Medium:
                    freshWeapon = new Minigun(21, 500, 500);
                    break;
                case Category.Heavy:
                    freshWeapon = new Cannon(21, 100, 80);
                    break;
                default:
                    break;
            }

            _inventory.Add(freshWeapon);
            Assert.AreEqual(21, _inventory.Capacity);

            var allWeapons = _inventory.RetrieveAll();
            int firstIndex = allWeapons.IndexOf(_savedWeapon);
            int secondIndex = allWeapons.IndexOf(freshWeapon);

            _inventory.Swap(_savedWeapon, freshWeapon);
            allWeapons = _inventory.RetrieveAll();

            Assert.AreEqual(firstIndex, allWeapons.IndexOf(freshWeapon));
            Assert.AreEqual(secondIndex, allWeapons.IndexOf(_savedWeapon));
        }

        [Test]
        public void RetrieveAllWorksCorrectly()
        {
            var allWeapons = _inventory.RetrieveAll();

            Assert.AreEqual(20, allWeapons.Capacity);
        }

        [Test]
        public void ClearWorksCorrectly()
        {
            _inventory.Clear();

            Assert.AreEqual(0, _inventory.Capacity);
        }


        [Test]
        public void RetrieveInRangeWorksCorrectly()
        {
            _inventory.Add(new Minigun(22, 200, 200));
            _inventory.Add(new Cannon(23, 200, 200));

            List<IWeapon> weaponsInRange = _inventory.RetrieveAll()
                .Where(w => (int)w.Category >= 1 && (int)w.Category <= 2)
                .OrderBy(w => w.Id)
                .ToList();

            List<IWeapon> actualWeapons = _inventory
                .RetriveInRange(Category.Medium, Category.Heavy)
                .OrderBy(w => w.Id)
                .ToList(); ;

            Assert.AreEqual(weaponsInRange.Capacity, actualWeapons.Capacity);

            for (int i = 0; i < weaponsInRange.Count; i++)
            {
                Assert.AreEqual(weaponsInRange[i], actualWeapons[i]);
            }
        }

        [Test]
        public void EmptyArsenalWorksCorrectly()
        {
            _inventory.Add(new Pistol(21, 200, 200));

            _inventory.EmptyArsenal(Category.Light);

            var allLightWeapons = _inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Light);

            foreach (var weapon in allLightWeapons)
            {
                Assert.AreEqual(0, weapon.Ammunition);
            }
        }

        [Test]
        public void RemoveHeavyWorksCorrectly()
        {
            _inventory.Add(new Cannon(21, 200, 200));
            int expectedCount = _inventory.RetrieveAll()
                .Count(w => w.Category == Category.Heavy);

            int actualCount = _inventory.RemoveHeavy();
            var allHeavyWeapons = _inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Heavy);

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsEmpty(allHeavyWeapons);
        }

        [Test]
        public void EnumeratorWorksCorrectly()
        {
            int count = 0;
            foreach (var weapon in _inventory)
            {
                count++;
            }

            Assert.AreEqual(20, count);
        }
    }
}