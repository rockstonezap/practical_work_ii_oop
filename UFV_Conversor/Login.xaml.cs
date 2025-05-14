using Microsoft.Extensions.Logging;

namespace UFV_Conversor;

public partial class Login : ContentPage {

    public Login() {
        InitializeComponent();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private void Exit(object sender, EventArgs e) {
        if (App.Current != null) {
            Application.Current.Quit();
        }
    }
}
