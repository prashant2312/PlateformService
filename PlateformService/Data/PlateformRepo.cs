using PlateformService.Models;

namespace PlateformService.Data
{
    public class PlateformRepo : IPlateformRepo
    {
        private readonly AppDbContext _context;
        public PlateformRepo(AppDbContext context) 
        {
            _context=context;
        }
        public void CreatePlateform(Plateform plateform)
        {
            if (plateform == null)
            {
                throw new ArgumentNullException(nameof(plateform));
            }else
            {
                _context.Plateforms.Add(plateform);
            }
        }

        public IEnumerable<Plateform> GetAllPlateforms()
        {
            return _context.Plateforms.ToList();
        }

        public Plateform GetPlateformById(int id)
        {
            return _context.Plateforms.FirstOrDefault(e=>e.Id==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
