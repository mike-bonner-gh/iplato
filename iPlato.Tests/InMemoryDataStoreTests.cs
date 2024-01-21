using iPlato.Data;
using iPlato.Models;

namespace iPlato.Tests
{
    [TestClass]
    public class InMemoryDataStoreTests
    {
        private InMemoryDataStore dataStore;

        public InMemoryDataStoreTests()
        {
            dataStore = new InMemoryDataStore();
        }

        [TestMethod]
        public void AddOneUser()
        {
            Person person = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            dataStore.People.Add(person);

            Assert.IsTrue(dataStore.People.Count == 1);
        }

        [TestMethod]
        public void AddAndThenRemoveOneUser()
        {
            Person person = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            dataStore.People.Add(person);

            Assert.IsTrue(dataStore.People.Count == 1);

            dataStore.People.Remove(person);
        }

        [TestMethod]
        public void AddTwoUsers()
        {
            Person person1 = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            Person person2 = new Person()
            {
                Name = "User2",
                DateOfBirth = "02/06/1976",
                Profession = "QA Analyst Developer"
            };

            dataStore.People.Add(person1);
            dataStore.People.Add(person2);

            Assert.IsTrue(dataStore.People.Count == 2);
        }

        [TestMethod]
        public void AddThenEditOneUser()
        {
            Person person1 = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            dataStore.People.Add(person1);

            Assert.IsTrue(dataStore.People.Count == 1);
            Assert.IsTrue(dataStore.People.First().Equals(person1));

            var personToEdit = dataStore.People.First();
            personToEdit.Name = "UpdatedName";

            dataStore.UpdatePerson(personToEdit);

            Assert.IsTrue(dataStore.People.First().Equals(personToEdit));
        }

        [TestMethod]
        public void UpdateUserWithoutPreviouslyAdding()
        {
            Person person1 = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            dataStore.UpdatePerson(person1);

            Assert.IsTrue(dataStore.People.Count == 1);
            Assert.IsTrue(dataStore.People.First().Equals(person1));
        }

        [TestMethod]
        public void AddTwoUsersRemoveFirstAdded()
        {
            Person person1 = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            Person person2 = new Person()
            {
                Name = "User1",
                DateOfBirth = "14/02/1980",
                Profession = "Software Developer"
            };

            dataStore.People.Add(person1);
            dataStore.People.Add(person2);

            dataStore.People.Remove(person1);
            Assert.IsTrue(dataStore.People.Count == 1);
            Assert.IsTrue(dataStore.People.First().Equals(person2));
        }
    }
}