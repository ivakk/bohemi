﻿using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface ISoftService
    {
        bool CreateSoft(SoftDTO newSoft);
        Soft GetSoftById(int id);
        bool DeleteSoft(int id);
        List<Soft> GetAllSoft();
        bool UpdateSoft(SoftDTO updateSoft);
        Task<List<Soft>> GetPaginationSoftsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalSoftsCountAsync();
        bool LikeSoft(LikedBeverage likedDrink);
        bool RemoveFromLikedSofts(LikedBeverage likedDrink);
        bool IsSoftLiked(LikedBeverage likedDrink);
    }
}
