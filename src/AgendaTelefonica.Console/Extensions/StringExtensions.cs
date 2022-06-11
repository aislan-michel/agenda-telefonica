namespace AgendaTelefonica.Console.Extensions;

public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false; // suggested by @TK-421
        }
        
        try 
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch 
        {
            return false;
        }
    }
    
    public static bool IsDigitsOnly(this string str)
    {
        return str.All(c => c is >= '0' and <= '9');
    }
}