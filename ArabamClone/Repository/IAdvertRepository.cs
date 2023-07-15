using ArabamClone.Model;

namespace ArabamClone.Repository
{
    public interface IAdvertRepository
    {
        Task<List<Advert>> GetAdverts(int? categoryId, decimal? price, string? gear, string? fuel, int? page);
        Task<Advert> GetById(int id);
        Task<bool> AddVisit(int advertId, string ipAdress);
    }
}
