using Microsoft.AspNetCore.Identity;

namespace Test_IOMundo.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
