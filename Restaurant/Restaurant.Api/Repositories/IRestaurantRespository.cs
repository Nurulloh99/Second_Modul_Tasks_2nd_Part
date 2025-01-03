using Restaurant.Api.DataAccess.Entities;

namespace Restaurant.Api.Repositories;

public interface IRestaurantRespository
{
    Guid WriteRestaurant(Restaurant restaurant);
}
