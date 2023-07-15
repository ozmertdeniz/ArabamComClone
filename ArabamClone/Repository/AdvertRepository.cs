using ArabamClone.Model;
using ArabamClone.Model.Data;
using Dapper;

namespace ArabamClone.Repository
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly AppDbContext context;
        public AdvertRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddVisit(int advertId, string ipAdress)
        {
            bool result = false;
            try
            {
                using (var connection = this.context.CreateConnection())
                {
                    var query = "INSERT INTO [dbo].[AdvertVisits]([advertId],[iPAdress],[visitDate]) VALUES (@advertId, @iPAdress, @visitDate)";

                    result = await connection.ExecuteAsync(query, new { advertId, ipAdress, visitDate = DateTime.Now }) > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<List<Advert>> GetAdverts(int? categoryId, decimal? price, string? gear, string? fuel, int? page)
        {
            using (var connection = this.context.CreateConnection())
            {
                string query = "Select * from Adverts where 1=1";

                if (categoryId != null)
                {
                    query += " AND categoryId = @categoryId";
                }
                if (gear != null)
                {
                    query += " AND gear = @gear";
                }
                if (fuel != null)
                {
                    query += " AND fuel = @fuel";
                }
                if (price != null)
                {
                    query += " AND price = @price";
                }
                if (page != null)
                {
                    query += " AND page = @page";
                }
                query += " order by price,year,km";

                var advertList = await connection.QueryAsync<Advert>(query, new { categoryId, gear, fuel, price, page });
                return advertList.ToList();
            }

        }

        public async Task<Advert> GetById(int id)
        {
            using (var connection = this.context.CreateConnection())
            {
                string query = "Select * from Adverts where id = @id";

                var advert = await connection.QuerySingleAsync<Advert>(query, new { id });
                return advert;
            }
        }
    }
}
