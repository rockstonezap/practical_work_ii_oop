using Microsoft.Extensions.Logging;

namespace UFV_Conversor {

    public partial class Converter : ContentPage {

        public Converter() {
            InitializeComponent();
        }

        private async void GoToPrivacyPolicy(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("PrivacyPolicy");
        }
        
        // Operations (Alert Popup)

        // Logout (Get out of Account)

        private void Exit(object sender, EventArgs e) {
            if (App.Current != null) {
                Application.Current.Quit();
            }
        }
    }
}