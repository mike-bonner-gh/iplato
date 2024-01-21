using iPlato.Data;
using iPlato.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace iPlato
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            this.InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDataStore, InMemoryDataStore>();
            services.AddTransient<PersonEditorViewModel>();

            return services.BuildServiceProvider();
        }
    }
}