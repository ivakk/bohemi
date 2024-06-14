using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockSoftDAL : ISoftDAL
    {
        private List<Soft> softs = new List<Soft>();
        private List<LikedBeverage> likedSofts = new List<LikedBeverage>();

        public MockSoftDAL()
        {
            // Initialize with some dummy data
            softs.Add(new Soft(1, null, "Coke", 500, 1.5m, "Yes"));
            softs.Add(new Soft(2, null, "Pepsi", 500, 1.5m, "Yes"));
            softs.Add(new Soft(3, null, "Sprite", 500, 1.5m, "No"));

            likedSofts.Add(new LikedBeverage(1, 1));
            likedSofts.Add(new LikedBeverage(1, 2));
            likedSofts.Add(new LikedBeverage(2, 2));
        }

        public bool CreateSoftDAL(SoftDTO newSoft)
        {
            softs.Add(new Soft(softs.Max(s => s.Id) + 1, newSoft.Picture, newSoft.Name, newSoft.Size, newSoft.Price, newSoft.Carbonated));
            return true;
        }

        public Soft GetSoftByIdDAL(int id)
        {
            return softs.FirstOrDefault(s => s.Id == id);
        }

        public bool DeleteSoftDAL(int id)
        {
            var softToRemove = softs.FirstOrDefault(s => s.Id == id);
            if (softToRemove != null)
            {
                softs.Remove(softToRemove);
                return true;
            }
            return false;
        }

        public List<Soft> GetAllSoftDAL()
        {
            return new List<Soft>(softs);
        }

        public bool UpdateSoftDAL(SoftDTO updateSoft)
        {
            var softToUpdate = softs.FirstOrDefault(s => s.Id == updateSoft.Id);
            if (softToUpdate != null)
            {
                softs.Remove(GetSoftByIdDAL(updateSoft.Id));
                softs.Add(new Soft(updateSoft.Id, updateSoft.Picture, updateSoft.Name, updateSoft.Size, updateSoft.Price, updateSoft.Carbonated));
                return true;
            }
            return false;
        }

        public bool LikeSoftDAL(LikedBeverage likedDrink)
        {
            if (!likedSofts.Any(ls => ls.UserId == likedDrink.UserId && ls.BeverageId == likedDrink.BeverageId))
            {
                likedSofts.Add(likedDrink);
                return true;
            }
            return false;
        }

        public bool RemoveFromLikedSoftsDAL(LikedBeverage likedDrink)
        {
            var likedToRemove = likedSofts.FirstOrDefault(ls => ls.UserId == likedDrink.UserId && ls.BeverageId == likedDrink.BeverageId);
            if (likedToRemove != null)
            {
                likedSofts.Remove(likedToRemove);
                return true;
            }
            return false;
        }

        public bool IsSoftLikedDAL(LikedBeverage likedDrink)
        {
            return likedSofts.Any(ls => ls.UserId == likedDrink.UserId && ls.BeverageId == likedDrink.BeverageId);
        }

        public Task<List<Soft>> GetPaginationSoftsDALAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalSoftsCountDALAsync()
        {
            throw new NotImplementedException();
        }
    }
}
