using System.Linq;
using HappyXamDevs.Services;
using Xamarin.Forms;

namespace HappyXamDevs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var azureService = DependencyService.Get<IAzureService>();

            if (!azureService.IsLoggedIn() && !Navigation.ModalStack.Any())
            {
                    await Navigation.PushModalAsync(new LoginPage(), false);
            }
            else
            {
                PhotosListView.BeginRefresh();
            }
        }
    }
}