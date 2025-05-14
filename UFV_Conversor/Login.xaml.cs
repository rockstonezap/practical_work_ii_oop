using Microsoft.Extensions.Logging;

namespace UFV_Conversor;

public partial class Login : ContentPage {

    public Login() {
        InitializeComponent();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private async void ExecuteLogin(object sender, EventArgs e) {
        await Task.Delay(2000);
    }
    private async void GoToRecovery(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("Recovery");
    }

    private void Exit(object sender, EventArgs e) {
        if (App.Current != null) {
            Application.Current.Quit();
        }
    }
}
