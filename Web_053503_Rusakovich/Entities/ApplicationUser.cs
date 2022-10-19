using Microsoft.AspNetCore.Identity;

namespace Web_053503_Rusakovich.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] Image { get; set; }
    }
}
