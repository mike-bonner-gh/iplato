using iPlato.ViewModels;
using System.Windows.Controls;

namespace iPlato.Views
{
    /// <summary>
    /// Interaction logic for PersonEditor.xaml
    /// </summary>
    public partial class PersonEditor : Page
    {
        public PersonEditor()
        {
            InitializeComponent();
            Type type = typeof(PersonEditorViewModel);
            this.DataContext = App.Current.Services.GetService(type);
        }
    }
}