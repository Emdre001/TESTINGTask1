namespace TESTinlämning.Test;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void AddUser_UsernameTooShort()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();
        string username = "abc"; // Too short
        string password = "password123";
        string email = "test@example.com";

        // Act
        bool result = registrationService.AddUser(username, password, email);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddUser_UsernameTooLong()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();
        string username = "abcdefghijklmnopqrstu"; // Too long
        string password = "password123";
        string email = "test@example.com";

        // Act
        bool result = registrationService.AddUser(username, password, email);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Adduser_UsernameAlreadyExsists()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();
        string username = "existingUser";
        string password = "password123";
        string email = "existinguser@example.com";

        // Act
        registrationService.AddUser(username, password, email);
        bool result = registrationService.AddUser(username, password, email);

        // Assert
        Assert.IsFalse(result, "User registration should fail for an existing username.");
    }

    [TestMethod]
    public void AddUser_NonAplhanumeric()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();
        string username = "abc$123";
        string password = "password123";
        string email = "test@example.com";

        // Act
        bool result = registrationService.AddUser(username, password, email);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddPassword_TooShort()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddPassword("abc123", "Pass1!", "Test@example.com");

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddPassword_NoSpecialCharacter()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddPassword("abc123", "Password1", "Test@example.com");

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddPassword_ValidPassword()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddPassword("abc123", "Password1!", "Test@example.com");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AddEmail_InvalidFormat_NoAtsign()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddEmail("abc123", "Password1!", "Testexample.com");

        // Assert

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddEmail_InvalidFormat_NoDot()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddEmail("abc123", "Password1!", "Test@examplecom");

        // Assert

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddEmail_CorrectFormat()
    {
        // Arrange
        RegistrationService registrationService = new RegistrationService();

        // Act
        bool result = registrationService.AddEmail("abc123", "Password1!", "Test@example.com");

        // Assert

        Assert.IsTrue(result);


    }







}
