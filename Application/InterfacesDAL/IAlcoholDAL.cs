using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface IAlcoholDAL
    {
        bool CreateAlcoholDAL(AlcoholDTO newAlcohol);
        Alcohol GetAlcoholByIdDAL(int id);
        bool DeleteAlcoholDAL(int id);
        List<Alcohol> GetAllAlcoholsDAL();
        bool UpdateAlcoholDAL(AlcoholDTO newAlcohol);
        Task<int> GetTotalAlcoholsCountDALAsync();
        Task<List<Alcohol>> GetPaginationAlcoholsDALAsync(int pageNumber, int pageSize);
        bool LikeAlcoholDAL(LikedBeverage likedDrink);
        bool RemoveFromLikedAlcoholsDAL(LikedBeverage likedDrink);
        bool IsAlcoholLikedDAL(LikedBeverage likedDrink);
        List<LikedBeverage> GetLikedBeveragesDAL();
    }
}
