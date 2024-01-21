using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace iPlato.Models
{
    public class Person : INotifyPropertyChanged
    {
        #region Private properties

        private Guid id;
        private String name;
        private String dateOfBirth;
        private String profession;

        #endregion

        #region Public properties

        public Guid Id
        {
            get => id;
        }

        public String Name {
            get => name;
            set {
                name = value;
                OnPropertyChanged();
                HasBeenUpdated = true;
            }
        }

        public String DateOfBirth {
            get => dateOfBirth;
            set {
                dateOfBirth = value;
                OnPropertyChanged();
                HasBeenUpdated = true;
            }
        }

        public String Profession {
            get => profession;
            set {
                profession = value;
                OnPropertyChanged();
                HasBeenUpdated = true;
            }
        }

        public Boolean HasBeenUpdated { get; set; } = false;

        #endregion

        #region Constructor

        public Person()
        {
            id = Guid.NewGuid();
            HasBeenUpdated = false;
        }

        #endregion

        #region PropertyChanged behaviours

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}