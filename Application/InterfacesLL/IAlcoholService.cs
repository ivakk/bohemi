using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IAlcoholService
    {
        bool CreateAlcohol(AlcoholDTO newAlcohol);
        Alcohol GetAlcoholById(int id);
        bool DeleteAlcohol(int id);
        List<Alcohol> GetAllAlcohols();
        bool UpdateAlcohol(AlcoholDTO newAlcohol);
        List<Alcohol> GetAlcoholsBySearch(string search);
        List<Alcohol> GetFirstAlcohols(int count);
        Task<List<Alcohol>> GetPaginationAlcoholsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalAlcoholsCountAsync();
        bool LikeAlcohol(LikedBeverage likedDrink);
        bool RemoveFromLikedAlcohols(LikedBeverage likedDrink);
        bool IsAlcoholLiked(LikedBeverage likedDrink);
        List<LikedBeverage> GetLikedBeverages();
    }
}
