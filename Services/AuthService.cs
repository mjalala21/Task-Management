using StudentApi.Models;
namespace StudentApi.Services
{
    public class AuthService
    {
        private static List<User> users = new List<User>();

        public User? Register(RegisterModel model)
        {

            Console.WriteLine("REGISTER METHOD REACHED");
            var existingUser = users.FirstOrDefault(
                u => u.Username == model.Username
                );

            if(existingUser != null)
            {
                return null;
            }

            var user = new User
            {
                Id = users.Count + 1,
                Username = model.Username,
                Password = model.Password,
                Role = model.Role

            };

            users.Add(user);
            return user;

        }

        public User? Login (LoginModel model)
        {
            var user = users.FirstOrDefault(
                u => u.Username == model.Username &&
                   u.Password == model.Password
                );

            return user;
        }
    }
}
