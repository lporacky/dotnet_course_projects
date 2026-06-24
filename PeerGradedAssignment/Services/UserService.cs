using Backend.Models;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 25 },
        new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 30 }
    };

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(User user)
    {
        user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
        return user;
    }

    public bool Update(int id, User user)
    {
        var existingUser = GetById(id);

        if (existingUser == null)
            return false;

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Age = user.Age;

        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);

        if (user == null)
            return false;

        _users.Remove(user);
        return true;
    }
}