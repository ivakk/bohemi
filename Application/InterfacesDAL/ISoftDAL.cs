using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface ISoftDAL
    {
        bool CreateSoftDAL(SoftDTO newSoft);
        Soft GetSoftByIdDAL(int id);
        bool DeleteSoftDAL(int id);
        List<Soft> GetAllSoftDAL();
        bool UpdateSoftDAL(SoftDTO updateSoft);
        Task<List<Soft>> GetPaginationSoftsDALAsync(int pageNumber, int pageSize);
        Task<int> GetTotalSoftsCountDALAsync();
        bool LikeSoftDAL(LikedBeverage likedDrink);
        bool RemoveFromLikedSoftsDAL(LikedBeverage likedDrink);
        bool IsSoftLikedDAL(LikedBeverage likedDrink);
    }
}
