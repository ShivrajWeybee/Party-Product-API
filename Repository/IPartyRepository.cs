using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IPartyRepository
    {
        Task<List<PartyModel>> GetAllParty();
        Task<PartyModel> GetPartyById(int id);
        Task<int> AddNewParty(PartyModel party);
        Task<int> UpdateParty(int id, PartyModel party);
        Task DeleteParty(int id);
    }
}