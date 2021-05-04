using MyTourist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTourist.Services
{
    public class MookTouristRouteRepositoty 
    {

        private List<TouristRoute> _routes;
        public MookTouristRouteRepositoty()
        {
            if (_routes == null)
            {
                InitializeTouristRoutes();
            }
        }


        private void InitializeTouristRoutes()
        {
            _routes = new List<TouristRoute>
            {
                  new TouristRoute{
               Id = Guid.NewGuid(),
               Title = "黄山",
               Description  = "黄山真好玩",
               OriginalPrice = 1299,
               Features = "吃住行有狗",
               Fees = "交通费自理",
               Notes ="小心危险"

           },  new TouristRoute{
               Id = Guid.NewGuid(),
               Title = "黄山",
               Description  = "黄山真好玩",
               OriginalPrice = 1299,
               Features = "吃住行有狗",
               Fees = "交通费自理",
               Notes ="小心危险"

           }

            };
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {

            return _routes;

        }


        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _routes.FirstOrDefault(n => n.Id == touristRouteId);
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }
    }
}
