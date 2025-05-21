using Microsoft.Extensions.Logging;

namespace UFV_Conversor {

    public partial class PrivacyPolicy : ContentPage {

        public PrivacyPolicy() {
            InitializeComponent();
        }

        private async void ReturnToHomepage(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("Homepage");
        }
        
        private void Exit(object sender, EventArgs e) {
            if (App.Current != null) {
                Application.Current.Quit();
            }
        }
    }
}