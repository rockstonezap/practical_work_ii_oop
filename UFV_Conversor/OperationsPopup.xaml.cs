using CommunityToolkit.Maui.Views;

namespace UFV_Conversor;

// Gets all information into the Popup "Page"
public partial class OperationsPopup : Popup
{
    public OperationsPopup(string[] userData)
    {
        InitializeComponent();

        Name.Text = userData[0];
        Username.Text = userData[1];
        Email.Text = userData[2];
        Password.Text = userData[3];
        NumberOperations.Text = userData[4];
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}
