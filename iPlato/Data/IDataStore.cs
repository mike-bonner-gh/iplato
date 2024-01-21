using iPlato.Models;

namespace iPlato.Data
{
    public interface IDataStore
    {
        List<Person> People { get; }

        void LoadPeople();

        void SavePeople();

        void AddPerson(Person person);

        void DeletePerson(Person person);

        void UpdatePerson(Person person);
    }
}