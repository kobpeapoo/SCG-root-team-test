using restuarant_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_web_api.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<GoogleMapResModel> GetRestaurant(string areaName);
    }
}
