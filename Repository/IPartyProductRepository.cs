using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IPartyProductRepository
    {
        Task<List<PartyProductModel>> GetAllAssignAsync();
        Task<PartyProductModel> GetAssignById(int id);
        Task<int> AddNewAssignAsync(PartyProductModel assign);
        Task UpdateAssignAsync(int id, PartyProductModel assign);
        Task DeleteAssignAsync(int id);
    }
}