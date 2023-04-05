using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatStore
{
    public class UserRoleCheck
    {
        public int Id { get; }
        public string Login { get; set; }

        public int Role { get; }

        public string Status => Role == 1 ? "Админ" : "Пользователь";

        public UserRoleCheck(int id, string login, int role) 
        {
            Id = id;
            Login = login.Trim();
            Role = role;
        }

            
    }
}
