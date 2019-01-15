using Models;

namespace BusinessLayer.Interfaces
{
    public interface IHotelService : IService<Hotel>
    {
        Hotel FindByName(string name);
    }
}