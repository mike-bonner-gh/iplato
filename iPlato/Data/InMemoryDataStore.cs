using iPlato.Models;

namespace iPlato.Data
{
    public class InMemoryDataStore : IDataStore
    {
        public List<Person> People { get; set; }
        public InMemoryDataStore()
        {
            People = new List<Person>();
        }

        public void LoadPeople()
        {
            List<Person> result = new List<Person>
            {
                new Person() { Name = "Mike", DateOfBirth = "13/02/1980", Profession = "Developer" },
                new Person() { Name = "Dave", DateOfBirth = "11/08/1975", Profession = "Manager" },
                new Person() { Name = "Jim", DateOfBirth = "04/11/1965", Profession = "QA" }
            };

            this.People = result;
        }

        public void SavePeople()
        {
            //As we're an in memory datastore, we're happy to not save this data back.
        }

        public void AddPerson(Person person)
        {
            this.People.Add(person);
        }

        public void DeletePerson(Person person)
        {
            this.People.Remove(person);
        }

        public void UpdatePerson(Person person)
        {
            var item = this.People.Find(p => p.Id == person.Id);
            if (item != null)
            {
                var index = this.People.IndexOf(item);

                if (index != -1)
                {
                    this.People[index] = person;
                    return;
                }
            }

            //We're happy to add the person here if they've not been previously added to the list.
            this.People.Add(person);
        }
    }
}