namespace backend.Dto.Requests.User;

public record SignInRequest
(
    string Email,
    string Password);