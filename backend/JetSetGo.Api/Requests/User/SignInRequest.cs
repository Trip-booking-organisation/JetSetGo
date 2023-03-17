namespace backend.Requests.User;

public record SignInRequest
(
    string Email,
    string Password);