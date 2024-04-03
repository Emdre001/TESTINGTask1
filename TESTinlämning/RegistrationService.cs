namespace TESTinlämning;

public class RegistrationService
{
    public List<string> Users { get; set; } = new List<string>();

    public bool AddUser(string username, string password, string email)
    {
        if (username.Length < 5 || username.Length > 20)
        {
            Console.WriteLine("Username must be between 5 and 20 characters long.");
            return false;
        }

        if (!IsAlphanumeric(username))
        {
            Console.WriteLine("Username must contain only alphanumeric characters.");
            return false;
        }

        if (Users.Contains(username))
        {
            Console.WriteLine("Username already exists.");
            return false;
        }

        User newUser = new User(username, password, email);
        Users.Add(username);
        Console.WriteLine($"Username {username} added successfully.");
        return true;
    }

    public bool IsAlphanumeric(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    public bool AddPassword(string username, string password, string email)
    {
        if (password.Length < 8)
        {
            Console.WriteLine($"Password is too short");
            return false;
        }

        if (!ContainsSpecialCharacter(password))
        {
            Console.WriteLine($"Password must contain at least one special character");
            return false;
        }

        Console.WriteLine("Password added successfully");
        return true;
    }

    private bool ContainsSpecialCharacter(string password)
    {
        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
            {
                return true;
            }
        }
        return false;
    }

    public bool AddEmail(string username, string password, string email)
    {
        if(!ValidEmail(email))
        {
            Console.WriteLine("Error. Invalid Email format");
            return false; 
        }
        Console.WriteLine("Email added successfully");
        return true;
    }

    private bool ValidEmail(string email)
    {
        if (email.Contains("@") && email.Contains("."))
        {
            return true;
        }
        return false;
    }
}
