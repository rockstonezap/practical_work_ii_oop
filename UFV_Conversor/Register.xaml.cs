using System.ComponentModel.DataAnnotations;

namespace UFV_Conversor;

public partial class Register : ContentPage
{
    private PasswordValidator passwordChecker = new PasswordValidator();
    private AccountsData Data = new AccountsData();

    public Register()
    {
        InitializeComponent();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private async void RegisterUser(object sender, EventArgs e)
    {
        // Get Containarised location for files for App and add Accounts Directory
        string folderPath = Path.Combine(FileSystem.AppDataDirectory, "Accounts");
        Directory.CreateDirectory(folderPath);

        string filePath = Path.Combine(folderPath, "accounts.csv");
        string separator = ";";

        /*
        // For Debugging Purposes; Checks the full path for filePath

        string fullPath = Path.GetFullPath(filePath);
        await DisplayAlert("Path", Path.GetFullPath(filePath), "OK");  
        */

        // Entry items for file
        string name = nameEntry.Text;
        string username = userNameEntry.Text;
        string email = userEmailEntry.Text;
        string password = userPasswordEntry.Text;
        string numOperations = "0";

        string information = name + separator + username + separator + email + separator + password + separator + numOperations;

        try
        {
            bool isChecked = privacyPolicyBox.IsChecked;
            string passwordConfirm = passConfirmEntry.Text;

            // Basic checkup on conditions for proper registration
            if (privacyPolicyBox.IsChecked == false)
                throw new ValidationException("You must agree to the terms before continuing.");
            else if (name == username)
                throw new FormatException("Name and username cannot be the same.");
            else if (password != passwordConfirm)
                throw new FormatException("Password confirmation failed. Passwords must match.");

            passwordChecker.Validate(password);

            Data.AddUser(information);

            await DisplayAlert("User Registration: ", $"User registration of {username} was successful", "OK");

            await Shell.Current.GoToAsync("Login");
        }
        catch (ValidationException ex)
        {
            await DisplayAlert("Terms Not Accepted: ", ex.Message, "OK");
        }
        catch (FormatException ex)
        {
            await DisplayAlert("Format Error: ", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.GetType().Name + ": " + ex.Message, "OK");
        }
    }

    private void Exit(object sender, EventArgs e)
    {
        if (App.Current != null)
        {
            Application.Current.Quit();
        }
    }
}
