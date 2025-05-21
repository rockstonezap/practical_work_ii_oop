namespace UFV_Conversor;

public class PasswordValidator : InputValidator
{
    public override void Validate(string password)
    {
        int lengthPassword = password.Count();

        if (lengthPassword < 8)
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
    }
}
