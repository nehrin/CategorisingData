using CategorisingDataForPets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CategorisingDataTest
{
    [TestClass]
    public class CategorisingDataTest
    {
        List<Person> people = new List<Person>();

        [TestInitialize]
        public void SetUp()
        {
            Person bob = new Person("Bob", 23, Gender.Male);
            Pet garfield1 = new Pet("Garfield", "Cat");
            Pet fido = new Pet("Fido", "Dog");
            bob.Pets = new List<Pet>() { garfield1, fido };

            people.Add(bob);

            Person jennifer = new Person("Jennifer", 18, Gender.Female);
            Pet garfield2 = new Pet("Garfield", "Cat");
            jennifer.Pets = new List<Pet>() { garfield2 };

            people.Add(jennifer);

            Person steve = new Person("Steve", 45, Gender.Male);
            steve.Pets = null;

            people.Add(steve);

            Person fred = new Person("Fred", 40, Gender.Male);
            Pet tom = new Pet("Tom", "Cat");
            Pet max = new Pet("Max", "Cat");
            Pet sam = new Pet("Sam", "Dog");
            Pet jim = new Pet("Jim", "Cat");
            fred.Pets = new List<Pet>() { tom, max, sam, jim };

            people.Add(fred);

            Person samantha = new Person("Samantha", 40, Gender.Female);
            Pet tabby = new Pet("Tabby", "Cat");
            samantha.Pets = new List<Pet>() { tabby };

            people.Add(samantha);

            Person alice = new Person("Alice", 64, Gender.Female);
            Pet simba = new Pet("Simba", "Cat");
            Pet nemo = new Pet("Nemo", "Fish");
            alice.Pets = new List<Pet>() { simba, nemo };

            people.Add(alice);
        }

        [TestMethod]
        public void TestGetPetsListOrderedAlphabeticallyByOwnerGender_WithMaleOwner()
        {
            CategorisingData categoriseData = new CategorisingData();
            List<Pet> petsMale = categoriseData.GetPetsListOrderedAlphabeticallyByOwnerGender(Gender.Male, people);

            Assert.AreEqual(6, petsMale.Count);
            Assert.AreEqual("Fido", petsMale[0].Name);
            Assert.AreEqual("Garfield", petsMale[1].Name);
            Assert.AreEqual("Jim", petsMale[2].Name);
            Assert.AreEqual("Max", petsMale[3].Name);
            Assert.AreEqual("Sam", petsMale[4].Name);
            Assert.AreEqual("Tom", petsMale[5].Name);
        }

        [TestMethod]
        public void TestGetPetsListOrderedAlphabeticallyByOwnerGender_WithFemaleOwner()
        {
            CategorisingData categoriseData = new CategorisingData();
            List<Pet> petsFemale = categoriseData.GetPetsListOrderedAlphabeticallyByOwnerGender(Gender.Female, people);

            Assert.AreEqual(4, petsFemale.Count);
            Assert.AreEqual("Garfield", petsFemale[0].Name);
            Assert.AreEqual("Nemo", petsFemale[1].Name);
            Assert.AreEqual("Simba", petsFemale[2].Name);
            Assert.AreEqual("Tabby", petsFemale[3].Name);
        }
    }
}
