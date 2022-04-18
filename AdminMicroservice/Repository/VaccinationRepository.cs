using AdminMicroservice.Data;
using AdminMicroservice.Model;
using System.Collections.Generic;
using System.Linq;
using VaccinationMicroservice.Repository.IRepository;

namespace VaccinationMicroservice.Repository
{
    public class VaccinationRepository:IVaccinationRepository
    {
        private readonly ApplicationDbContext _db;

        public VaccinationRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public bool CreateVaccination(Vaccination Vaccination)
        {
            _db.Vaccinationstock.Add(Vaccination);
            return Save();
        }

        public bool DeleteVaccination(Vaccination Vaccination)
        {
            _db.Vaccinationstock.Remove(Vaccination);
            return Save();
        }

        public ICollection<Vaccination> GetVaccinations()
        {
            return _db.Vaccinationstock.OrderBy(a => a.Id).ToList();
        }

        public bool VaccinationExists(int id)
        {
            return _db.Vaccinationstock.Any(a => a.Id == id);

        }
        public Vaccination GetVaccination(int id)
        {
            return _db.Vaccinationstock.FirstOrDefault(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public bool UpdateVaccination(Vaccination Vaccination)
        {
            _db.Vaccinationstock.Update(Vaccination);
            return Save();
        }

    }
}
