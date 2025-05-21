using CommunityToolkit.Maui.Views;

namespace UFV_Conversor;

// Gets all information into the Popup "Page"
public partial class OperationsPopup : Popup
{
    public OperationsPopup(string[] userData)
    {
        InitializeComponent();
        this.Size = new Size(800, 800);

        Name.Text = userData[0];
        UserName.Text = userData[1];
        Email.Text = userData[2];
        Password.Text = userData[3];
        NumberOperations.Text = userData[4];
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}
