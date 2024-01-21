using iPlato.Models;
using iPlato.ViewModels;

namespace iPlato.Tests
{
    [TestClass]
    public class PersonEditorViewModelTests
    {
        private PersonEditorViewModel viewModel;
        private MockDataStore dataStore;

        public PersonEditorViewModelTests()
        {
            dataStore = new MockDataStore();
            viewModel = new PersonEditorViewModel(dataStore);
        }

        [TestMethod]
        public void TestLoadingPeople()
        {
            viewModel.LoadPeopleCommand.Execute(null);
            Assert.IsTrue(viewModel.PersonList.Count == 2);
        }

        [TestMethod]
        public void TestLoadingPeopleThenDeletingPerson()
        {
            viewModel.LoadPeopleCommand.Execute(null);
            Assert.IsTrue(viewModel.PersonList.Count == 2);

            viewModel.SelectedPerson = viewModel.PersonList.First();

            viewModel.DeletePersonCommand.Execute(null);
            Assert.IsTrue(viewModel.PersonList.Count == 1);
        }

        [TestMethod]
        public void TestDeleteCommandEnabledWhenPersonListNotEmptyAndPersonSelected()
        {
            viewModel.LoadPeopleCommand.Execute(null);
            viewModel.SelectedPerson = viewModel.PersonList.First();
            Assert.IsTrue(viewModel.DeletePersonCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestDeleteCommandDisabledWhenPersonListNotEmptyAndNoPersonSelected()
        {
            viewModel.LoadPeopleCommand.Execute(null);
            Assert.IsFalse(viewModel.DeletePersonCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestDeleteCommandDisabledWhenPersonListEmpty()
        {
            Assert.IsFalse(viewModel.DeletePersonCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestAddingPerson()
        {
            Person person = new Person
            {
                Name = "User1",
                DateOfBirth = "16/05/1982",
                Profession = "Manager"
            };

            viewModel.PersonList.Add(person);

            Assert.IsTrue(viewModel.PersonList.Count == 1);
        }
    }
}