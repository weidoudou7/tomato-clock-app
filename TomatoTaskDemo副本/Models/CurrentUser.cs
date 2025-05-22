using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTaskDemo.Models
{
    internal class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);
    }
}
