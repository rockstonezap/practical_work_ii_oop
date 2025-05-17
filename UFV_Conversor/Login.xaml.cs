using System.ComponentModel.DataAnnotations;

namespace UFV_Conversor;

public partial class Login : ContentPage {

    public Login() {
        InitializeComponent();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private async void ExecuteLogin(object sender, EventArgs e)
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "Accounts/accounts.csv");

        try
        {
            using StreamReader reader = new StreamReader(filePath);

            string? line = "";

            string inputUsername = loginUsername.Text;
            string inputPassword = loginPassword.Text;
            bool found = false;

            while ((line = reader.ReadLine()) != null && !found)
            {
                // Order of Items: Name | Username | Email | Password NumberOperations
                string[] accountData = line.Split(";");

                string username = accountData[1];
                string password = accountData[3];

                if (username == inputUsername && password == inputPassword)
                {
                    found = true;
                }
            }

            if (found)
                await Shell.Current.GoToAsync("ConverterPage");
            else
                throw new ValidationException("Validation Failed: Please verify if your username or password are correct");

        }
        catch (ValidationException ex)
        {
            await DisplayAlert("Login Validation Error: ", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.GetType().Name + ": " + ex.Message, "OK");
        }
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
