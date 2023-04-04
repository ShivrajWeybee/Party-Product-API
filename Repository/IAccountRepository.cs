using Microsoft.AspNetCore.Identity;
using PartyProductAPI.Models;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LogInAsync(SignInModel signInModel);
    }
}