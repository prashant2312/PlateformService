using PlateformService.Models;

namespace PlateformService.Data
{
    public interface IPlateformRepo
    {
        bool SaveChanges();
        IEnumerable<Plateform> GetAllPlateforms();
        Plateform GetPlateformById(int id);
        void CreatePlateform(Plateform plateform );

    }
}
