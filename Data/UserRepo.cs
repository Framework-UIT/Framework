
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Helpers;
using Framework.Models;
namespace Framework.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly prod_frameworkContext _context;

        public UserRepo(prod_frameworkContext newContext)
        {
            _context = newContext;
        }
        private List<User> _user = new List<User>();

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var user = _context.User.SingleOrDefault(x => x.Username == username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("password is required");
            if (_context.User.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is alread taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            Console.WriteLine(Encoding.UTF8.GetString(passwordHash));
            // Console.WriteLine(Encoding.UTF8.GetString(passwordSalt));

            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // Console.WriteLine(hmac.Key);
                // Console.WriteLine(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.Default.GetBytes(password));

            }

        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

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