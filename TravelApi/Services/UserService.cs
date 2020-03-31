using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelApi.Models;
using TravelApi.Helpers;

namespace TravelApi.Services
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
    User GetById(int id);
    User Create(User user, string password);
    void Update(User user, string password = null);
    void Delete(int id);
  }

  public class UserService : IUserService
  {
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    // private List<User> _users = new List<User>
    // { 
    //   new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin },
    //   new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role = Role.User } 
    // };

    //private readonly AppSettings _appSettings;
    private DataContext _context;

    // public UserService(IOptions<AppSettings> appSettings, DataContext context)
    // {
    //   _appSettings = appSettings.Value;
    //   _context = context;
    // }

    public UserService(DataContext context)
    {
      _context = context;
    }

    public User Authenticate(string username, string password)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
      {
        return null;
      }
                
      var user = _context.Users.SingleOrDefault(x => x.Username == username);

      // return null if user not found // check if username exists
      if (user == null)
      {
        return null;
      }

      // check if password is correct
      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
      {
        return null;
      }
                
      // authentication successful so generate jwt token
      // var tokenHandler = new JwtSecurityTokenHandler();
      // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      // var tokenDescriptor = new SecurityTokenDescriptor
      // {
      //   Subject = new ClaimsIdentity(new Claim[] 
      //   {
      //     new Claim(ClaimTypes.Name, user.Id.ToString()),
      //     new Claim(ClaimTypes.Role, user.Role)
      //   }),
      //   Expires = DateTime.UtcNow.AddDays(7),
      //   SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      // };
      // var token = tokenHandler.CreateToken(tokenDescriptor);
      // user.Token = tokenHandler.WriteToken(token);

      // remove password before returning
      // user.PasswordHash = null;
      // user.PasswordSalt = null;

      // authentication successful
      return user;
    }

    // GET users
    public IEnumerable<User> GetAll()
    {
      // return users without passwords
      // return _users.Select(x => {
      //   x.Password = null;
      //   return x;
      // });
      return _context.Users;
    }

    public User GetById(int id) 
    {
      // var user = _users.FirstOrDefault(x => x.Id == id);

      // // return user without password
      // if (user != null) 
      // {
      //   user.Password = null;
      // }
      // return user;
      return _context.Users.Find(id);
    }

    public User Create(User user, string password)
    {
      // validation
      if (string.IsNullOrWhiteSpace(password))
      {
        throw new AppException("Password is required");
      }
          
      if (_context.Users.Any(x => x.Username == user.Username))
      {
        throw new AppException("Username \"" + user.Username + "\" is already taken");
      }
          
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      _context.Users.Add(user);
      _context.SaveChanges();

      return user;
    }

    public void Update(User userParam, string password = null)
    {
      var user = _context.Users.Find(userParam.Id);

      if (user == null)
      {
        throw new AppException("User not found");
      }
          
      if (userParam.Username != user.Username)
      {
        // username has changed so check if the new username is already taken
        if (_context.Users.Any(x => x.Username == userParam.Username))
        {
          throw new AppException("Username " + userParam.Username + " is already taken");
        }     
      }

      // update user properties
      user.FirstName = userParam.FirstName;
      user.LastName = userParam.LastName;
      user.Username = userParam.Username;

      // update password if it was entered
      if (!string.IsNullOrWhiteSpace(password))
      {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
      }

      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var user = _context.Users.Find(id);
      if (user != null)
      {
        _context.Users.Remove(user);
        _context.SaveChanges();
      }
    }

    // private helper methods
    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) 
      {
        throw new ArgumentNullException("password");
      }  
      if (string.IsNullOrWhiteSpace(password)) 
      {
        throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      }

      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null)
      {
        throw new ArgumentNullException("password");
      } 

      if (string.IsNullOrWhiteSpace(password)) 
      {
        throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      }  

      if (storedHash.Length != 64) 
      {
        throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      }

      if (storedSalt.Length != 128) 
      {
        throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
      }

      using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }
  }
}