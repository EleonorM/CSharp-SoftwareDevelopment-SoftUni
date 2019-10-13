namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenModelIsNullOrWhiteSpace()
        {
            string model = null;
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperModel()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(model, revenger.Model);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenWeightlIsEqualOrBelow0()
        {
            string model = "TestModel";
            double weight = 0;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperWeight()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(weight, revenger.Weight);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenPricelIsEqualOrBelow0()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 0m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperPrice()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(price, revenger.Price);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenAttacklIsBelow0()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = -1;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperAttack()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(attack, revenger.Attack);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenDefenselIsBelow0()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = -1;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperDefense()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(defense, revenger.Defense);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenHitPointsIsBelow0()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = -1;
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(model, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        public void Constructor_ShouldSetProperHitPoints()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            Assert.AreEqual(hitPoints, revenger.HitPoints);
        }

        [Test]
        public void TotalWeight_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);
            var expected = weight + partWeight;
            var actual = revenger.TotalWeight;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPrice_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);
            var expected = price + partPrice;
            var actual = revenger.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalAttack_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);
            var expected = attack + partAttackModifier;
            var actual = revenger.TotalAttack;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalDefense_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);
            var expected = defense;
            var actual = revenger.TotalDefense;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalHitPoints_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);
            var expected = hitPoints;
            var actual = revenger.TotalHitPoints;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddArsenalPart_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partAttackModifier = 2;
            var part = new ArsenalPart(partModel, partWeight, partPrice, partAttackModifier);

            revenger.AddArsenalPart(part);

            Assert.That(revenger.Parts.Contains(part));
        }

        [Test]
        public void AddShellPart_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partDefenceModifier = 2;
            var part = new ShellPart(partModel, partWeight, partPrice, partDefenceModifier);

            revenger.AddShellPart(part);

            Assert.That(revenger.Parts.Contains(part));
        }

        [Test]
        public void AddEndurancePart_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partHitPointsModifier = 2;
            var part = new EndurancePart(partModel, partWeight, partPrice, partHitPointsModifier);

            revenger.AddEndurancePart(part);

            Assert.That(revenger.Parts.Contains(part));
        }

        [Test]
        public void ToString_ShouldReturnCorrectValue()
        {
            string model = "TestModel";
            double weight = 5.5;
            decimal price = 10m;
            int attack = 10;
            int defense = 10;
            int hitPoints = 10;
            var assembler = new VehicleAssembler();
            var revenger = new Revenger(model, weight, price, attack, defense, hitPoints, assembler);

            string partModel = "PartModel1";
            double partWeight = 11.2;
            decimal partPrice = 5.5m;
            int partHitPointsModifier = 2;
            var part = new EndurancePart(partModel, partWeight, partPrice, partHitPointsModifier);
            string partModel2 = "PartModel2";
            double partWeight2 = 11.2;
            decimal partPrice2 = 5.5m;
            int partDefenceModifier2 = 2;
            var part2 = new ShellPart(partModel2, partWeight2, partPrice2, partDefenceModifier2);

            revenger.AddEndurancePart(part);
            revenger.AddShellPart(part2);

            var orderList = new List<IPart> { part, part2 };

            var result = new StringBuilder();

            result.AppendLine($"{nameof(Revenger)} - {model}");
            result.AppendLine($"Total Weight: {revenger.TotalWeight:F3}");
            result.AppendLine($"Total Price: {revenger.TotalPrice:F3}");
            result.AppendLine($"Attack: {revenger.TotalAttack}");
            result.AppendLine($"Defense: {revenger.TotalDefense}");
            result.AppendLine($"HitPoints: {revenger.TotalHitPoints}");

            result.Append("Parts: ");

            StringBuilder partsString = new StringBuilder();

            orderList.Select(x => x.Model)
                .ToList()
                .ForEach(x => partsString.Append(x).Append(", "));

            if (partsString.Length > 0)
            {
                string textToAppend = partsString.ToString()
                    .Substring(0, partsString.Length - 2);

                result.Append(textToAppend);
            }
            else
            {
                result.Append("None");
            }


            var actual = revenger.ToString();
            Assert.AreEqual(result.ToString(), actual);
        }
    }
}