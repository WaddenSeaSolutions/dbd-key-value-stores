using MongoExample.Domain.Interfaces;

namespace MongoExample.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}