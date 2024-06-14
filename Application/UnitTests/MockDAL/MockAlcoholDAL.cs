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
    public class MockAlcoholDAL : IAlcoholDAL
    {
        public List<Alcohol> alcohols = new List<Alcohol>();
        public List<LikedBeverage> likedAlcohols = new List<LikedBeverage>();

        public MockAlcoholDAL()
        {
            // Initialize with some dummy data
            alcohols.Add(new Alcohol(1, null, "Whiskey", 750, 50.0m, 40, 12));
            alcohols.Add(new Alcohol(2, null, "Vodka", 1000, 30.0m, 40, 5));
            alcohols.Add(new Alcohol(3, null, "Rum", 750, 25.0m, 35, 7));

            likedAlcohols.Add(new LikedBeverage(1, 1));
            likedAlcohols.Add(new LikedBeverage(1, 2));
            likedAlcohols.Add(new LikedBeverage(2, 2));
        }

        public bool CreateAlcoholDAL(AlcoholDTO newAlcohol)
        {
            alcohols.Add(new Alcohol(alcohols.Max(a => a.Id) + 1, newAlcohol.Picture, newAlcohol.Name, newAlcohol.Size, newAlcohol.Price, newAlcohol.Percentage, newAlcohol.Age));
            return true;
        }

        public Alcohol GetAlcoholByIdDAL(int id)
        {
            return alcohols.FirstOrDefault(a => a.Id == id);
        }

        public bool DeleteAlcoholDAL(int id)
        {
            var alcoholToRemove = alcohols.FirstOrDefault(a => a.Id == id);
            if (alcoholToRemove != null)
            {
                alcohols.Remove(alcoholToRemove);
                return true;
            }
            return false;
        }

        public List<Alcohol> GetAllAlcoholsDAL()
        {
            return new List<Alcohol>(alcohols);
        }

        public bool UpdateAlcoholDAL(AlcoholDTO updateAlcohol)
        {
            var alcoholToUpdate = alcohols.FirstOrDefault(a => a.Id == updateAlcohol.Id);
            if (alcoholToUpdate != null)
            {
                alcohols.Remove(GetAlcoholByIdDAL(updateAlcohol.Id));
                alcohols.Add(new Alcohol(updateAlcohol.Id, updateAlcohol.Picture, updateAlcohol.Name, updateAlcohol.Size, updateAlcohol.Price, updateAlcohol.Percentage,
                                        updateAlcohol.Age));
                return true;
            }
            return false;
        }

        public bool LikeAlcoholDAL(LikedBeverage likedDrink)
        {
            if (!likedAlcohols.Any(ld => ld.UserId == likedDrink.UserId && ld.BeverageId == likedDrink.BeverageId))
            {
                likedAlcohols.Add(likedDrink);
                return true;
            }
            return false;
        }

        public bool RemoveFromLikedAlcoholsDAL(LikedBeverage likedDrink)
        {
            var likedToRemove = likedAlcohols.FirstOrDefault(ld => ld.UserId == likedDrink.UserId && ld.BeverageId == likedDrink.BeverageId);
            if (likedToRemove != null)
            {
                likedAlcohols.Remove(likedToRemove);
                return true;
            }
            return false;
        }

        public bool IsAlcoholLikedDAL(LikedBeverage likedDrink)
        {
            return likedAlcohols.Any(ld => ld.UserId == likedDrink.UserId && ld.BeverageId == likedDrink.BeverageId);
        }

        public List<LikedBeverage> GetLikedBeveragesDAL()
        {
            return new List<LikedBeverage>(likedAlcohols);
        }

        public Task<int> GetTotalAlcoholsCountDALAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Alcohol>> GetPaginationAlcoholsDALAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
