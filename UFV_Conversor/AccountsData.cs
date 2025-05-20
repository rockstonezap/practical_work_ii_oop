using System.ComponentModel.DataAnnotations;
using System.IO;

namespace UFV_Conversor;

public class AccountsData
{
    private string FilePath;

    public AccountsData()
    {
        string folderPath = Path.Combine(FileSystem.AppDataDirectory, "Accounts");
        Directory.CreateDirectory(folderPath);

        this.FilePath = Path.Combine(folderPath, "accounts.csv");
    }

    public void AddUser(string information)
    {
        using StreamWriter writer = new StreamWriter(this.FilePath, true);

        writer.WriteLine(information);

        /*
        // Check where the user info was saved to
        // Uncomment this section and test the program to get the path to accounts.csv
        // If on macOS, in Finder use Cmd + Shift + G and then paste the path from this alert to the entry box

        await DisplayAlert("Saved To", filePath, "OK"); 
        */
    }

    public string[] SearchForUser(string username, string password, ref bool found)
    {
        using StreamReader reader = new StreamReader(this.FilePath);
        string line = "";
        string[] CurrentUserData = [];

        while ((line = reader.ReadLine()) != null && !found)
        {
            // Order of Items: Name | Username | Email | Password | NumberOperations
            string[] Data = line.Split(";");

            string currentUsername = Data[1];
            string currentPassword = Data[3];

            if (username == currentUsername && password == currentPassword)
            {
                found = true;

                CurrentUserData = Data;
            }
        }

        return CurrentUserData;
    }
    public void UpdatePasswordEntry(string username, string email, string password)
    {
        using StreamReader reader = new StreamReader(this.FilePath);

        string? line = "";
        bool found = false;
        List<string> documentText = new List<string>();

        int i = 0;
        // Reads file, adds each line to array and checks if username does exist 
        while ((line = reader.ReadLine()) != null)
        {
            // Order of Items: Name | Username | Email | Password | NumberOperations
            string[] accountData = line.Split(";");
 
            string currentUsername = accountData[1];
            string currentEmail = accountData[2];
            string oldPassword = accountData[3];

            if (username == currentUsername && email == currentEmail)
            {
                found = true;

                // Updates last added line in the list that goes through if check
                line = line.Replace(oldPassword, password);
            }

            documentText.Add(line);
            i++;
        }

        if (!found)
        {
            throw new ValidationException("Validation Failed: Please verify if your username or email are correct");
        }

        // Clearing file using append: false and reintroducing each line into the document
        using StreamWriter writer = new StreamWriter(this.FilePath, append: false);

        foreach (string item in documentText)
        {
            writer.WriteLine(item);
        }
    }
}
