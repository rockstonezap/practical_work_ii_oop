using System.ComponentModel.DataAnnotations;

namespace UFV_Conversor;

public partial class Register : ContentPage
{
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
            int lengthPassword = password.Count();

            bool isChecked = privacyPolicyBox.IsChecked;
            string passwordConfirm = passConfirmEntry.Text;

            // Basic checkup on conditions for proper registration
            if (privacyPolicyBox.IsChecked == true)
                throw new ValidationException("You must agree to the terms before continuing.");

            else if (name == username)
                throw new FormatException("Name and username cannot be the same.");

            else if (password != passwordConfirm)
                throw new FormatException("Password confirmation failed. Passwords must match.");

            else if (lengthPassword < 8)
                throw new FormatException("Password must be 8 characters or longer.");

            // Check whether password has correct requirements. Requirements of at least 1 up, 1 low, 1 num and 1 special
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            for (int i = 0; i < lengthPassword; i++)
            {
                char c = password[i];

                if (char.IsUpper(c))
                    hasUpper = true;

                else if (char.IsLower(c))
                    hasLower = true;

                else if (char.IsDigit(c))
                    hasDigit = true;

                else
                    hasSpecial = true;
            }

            // If any of them is false, the condition is true
            if (!(hasUpper && hasLower && hasDigit && hasSpecial))
                throw new FormatException(
                    "Password must include at least one uppercase letter, " +
                    "one lowercase letter, one number, and one special character."
                );

            using StreamWriter writer = new StreamWriter(filePath, true);

            writer.WriteLine(information);

            /*
            // Check where the user info was saved to
            // Uncomment this section and test the program to get the path to accounts.csv
            // If on macOS, in Finder use Cmd + Shift + G and then paste the path from this alert to the entry box

            await DisplayAlert("Saved To", filePath, "OK"); 
            */

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
