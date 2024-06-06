using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;
using InterfacesLL;
using InterfacesDAL;

namespace LogicLayer
{
    public class AlcoholService : IAlcoholService
    {
        private readonly IAlcoholDAL _alcoholDAL;

        public AlcoholService(IAlcoholDAL alcoholDAL)
        {
            this._alcoholDAL = alcoholDAL;
        }
        public bool CreateAlcohol(AlcoholDTO newAlcohol)
        {
            if (newAlcohol == null)
            {
                return false;
            }
            else if (newAlcohol.Picture == null || string.IsNullOrEmpty(newAlcohol.Name) || string.IsNullOrEmpty(newAlcohol.Size.ToString()) || string.IsNullOrEmpty(newAlcohol.Price.ToString())
                 || string.IsNullOrEmpty(newAlcohol.Percentage.ToString()) || string.IsNullOrEmpty(newAlcohol.Age.ToString()))
            {
                return false;
            }
            else
            {
                return _alcoholDAL.CreateAlcoholDAL(newAlcohol);
            }
        }

        public bool DeleteAlcohol(int id)
        {
            if (id < 0)
            {
                return false;
            }
            else
            {
                return _alcoholDAL.DeleteAlcoholDAL(id);
            }
        }

        public Alcohol GetAlcoholById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id");
            }
            else
            {
                return _alcoholDAL.GetAlcoholByIdDAL(id);
            }
        }

        public List<Alcohol> GetAllAlcohols()
        {
            return _alcoholDAL.GetAllAlcoholsDAL();
        }

        public bool UpdateAlcohol(AlcoholDTO newAlcohol)
        {
            if (newAlcohol == null)
            {
                return false;
            }
            else if (newAlcohol.Picture == null || string.IsNullOrEmpty(newAlcohol.Name) || string.IsNullOrEmpty(newAlcohol.Size.ToString()) || string.IsNullOrEmpty(newAlcohol.Price.ToString())
                 || string.IsNullOrEmpty(newAlcohol.Percentage.ToString()) || string.IsNullOrEmpty(newAlcohol.Age.ToString()))
            {
                return false;
            }
            else
            {
                return _alcoholDAL.UpdateAlcoholDAL(newAlcohol);
            }
        }

        public List<Alcohol> GetAlcoholsBySearch(string search)
        {
            List<Alcohol> result = new List<Alcohol>();
            foreach (Alcohol alcohol in GetAllAlcohols())
            {
                if (alcohol.GetObjectString().Contains(search))
                {
                    result.Add(alcohol);
                }
            }
            return result;
        }
        public List<Alcohol> GetFirstAlcohols(int count)
        {
            List<Alcohol> alcohols = new List<Alcohol>();
            int i = 0;
            foreach (Alcohol alcohol in GetAllAlcohols())
            {
                if (i < count)
                {
                    alcohols.Add(alcohol);
                    i++;
                }
                else
                {
                    break;
                }
            }
            return alcohols;
        }
        public async Task<List<Alcohol>> GetPaginationAlcoholsAsync(int pageNumber, int pageSize)
        {
            return await _alcoholDAL.GetPaginationAlcoholsDALAsync(pageNumber, pageSize);
        }
        public async Task<int> GetTotalAlcoholsCountAsync()
        {
            return await _alcoholDAL.GetTotalAlcoholsCountDALAsync();
        }

        public bool LikeAlcohol(LikedBeverage likedDrink)
        {
            if (likedDrink != null)
            {
                return _alcoholDAL.LikeAlcoholDAL(likedDrink);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public bool RemoveFromLikedAlcohols(LikedBeverage likedDrink)
        {
            if (likedDrink != null)
            {
                return _alcoholDAL.RemoveFromLikedAlcoholsDAL(likedDrink);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public bool IsAlcoholLiked(LikedBeverage likedDrink)
        {
            if (likedDrink != null)
            {
                return _alcoholDAL.IsAlcoholLikedDAL(likedDrink);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<LikedBeverage> GetLikedBeverages()
        {
            return _alcoholDAL.GetLikedBeveragesDAL();
        }
    }
}
