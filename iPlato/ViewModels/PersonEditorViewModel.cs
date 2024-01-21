
using CommunityToolkit.Mvvm.Input;
using iPlato.Data;
using iPlato.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace iPlato.ViewModels
{
    public class PersonEditorViewModel : INotifyPropertyChanged
    {
        #region Private properties

        private IDataStore _dataStore;

        private Person? selectedPerson;

        #endregion

        #region Public properties

        public ObservableCollection<Person> PersonList { get; set; } = new ObservableCollection<Person>();

        public Person? SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                SavePersonCommand.NotifyCanExecuteChanged();
                DeletePersonCommand.NotifyCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        public Boolean IsInEditMode { get; internal set; }

        #endregion

        #region Public commands

        public RelayCommand LoadPeopleCommand { get; }

        public RelayCommand SavePeopleCommand { get; }

        public RelayCommand AddPersonCommand { get; }

        public RelayCommand SavePersonCommand { get; }

        public RelayCommand DeletePersonCommand { get; }

        #endregion

        #region Constructor

        public PersonEditorViewModel(IDataStore dataStore)
        {
            _dataStore = dataStore;

            LoadPeopleCommand = new RelayCommand(LoadPeople);
            SavePeopleCommand = new RelayCommand(SavePeople);
            AddPersonCommand = new RelayCommand(AddPerson);
            SavePersonCommand = new RelayCommand(SavePerson, CanSavePerson);
            DeletePersonCommand = new RelayCommand(DeletePerson, CanDeletePerson);
        }

        #endregion

        #region Private methods

        private void LoadPeople()
        {
            _dataStore.LoadPeople();
            this.PersonList = new ObservableCollection<Person>(_dataStore.People);
            OnPropertyChanged("PersonList");
        }

        private void SavePeople()
        {
            _dataStore.SavePeople();
        }

        private void AddPerson()
        {
            //Reset the previous edit mode
            this.IsInEditMode = false;
            OnPropertyChanged("IsInEditMode");
            Person newPerson = new Person();

            _dataStore.AddPerson(newPerson);
            this.PersonList = new ObservableCollection<Person>(_dataStore.People);
            this.SelectedPerson = newPerson;

            //Signal to the UI that we are beginning edit mode so we want to move focus.
            this.IsInEditMode = true;
            OnPropertyChanged("IsInEditMode");
            OnPropertyChanged("SelectedPerson");
            OnPropertyChanged("PersonList");
        }

        private void SavePerson()
        {
            if (this.selectedPerson != null)
            {
                _dataStore.UpdatePerson(this.selectedPerson);
                OnPropertyChanged("PersonList");
            }
        }

        private Boolean CanSavePerson()
        {
            return this.PersonList != null && this.selectedPerson != null;
        }

        private void DeletePerson()
        {
            if (this.selectedPerson != null) 
            {
                _dataStore.DeletePerson(this.selectedPerson);
                this.PersonList = new ObservableCollection<Person>(_dataStore.People);
                OnPropertyChanged("PersonList");
            }
        }

        private Boolean CanDeletePerson()
        {
            return this.PersonList != null && this.selectedPerson != null;
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