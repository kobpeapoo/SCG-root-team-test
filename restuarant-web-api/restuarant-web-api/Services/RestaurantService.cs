using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using restaurant_web_api.Commons;
using restaurant_web_api.Services.Interfaces;
using restuarant_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace restaurant_web_api.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly string _tokenKey;
        private string _url;
        private readonly UtilityClass _utility;

        public RestaurantService(IConfiguration configuration)
        {
            //Set variable
            this._utility = new UtilityClass();
            this._tokenKey = configuration.GetValue<string>("token");
            this._url = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=restaurants+in+{0}&fields=photos,formatted_address,name,rating,opening_hours,geometry&locationbias=circle:2000@47.6918452,-122.2226413&key={1}";
            
        }
        public async Task<GoogleMapResModel> GetRestaurant(string areaName)
        {
            try
            {
                _url = string.Format(_url, areaName, _tokenKey);
                _url = HttpUtility.UrlPathEncode(_url);
                //Call Get Method
                string received = await _utility.CallGETMethod(_url);
                GoogleMapResModel listRestaurant = JsonConvert.DeserializeObject<GoogleMapResModel>(received);

                return listRestaurant;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
