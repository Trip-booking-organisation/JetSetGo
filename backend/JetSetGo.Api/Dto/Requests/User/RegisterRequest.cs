namespace backend.Dto.Requests.User;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Username
);

    

