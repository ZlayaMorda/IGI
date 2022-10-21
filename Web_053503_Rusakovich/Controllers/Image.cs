using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_053503_Rusakovich.Entities;

namespace Web_053503_Rusakovich.Controllers
{
    public class Image : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _env;

        public Image(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<FileResult> GetImage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Image == null)
                return File(_env.WebRootFileProvider
                    .GetFileInfo("images/i.jpg")
                    .CreateReadStream(), "image/...");
            else
            {
                return File(user.Image, "image/png");
            }
        }
    }
}
