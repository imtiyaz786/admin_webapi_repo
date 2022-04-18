using AdminMicroservice.Model;
using System.Collections.Generic;

namespace VaccinationMicroservice.Repository.IRepository
{
    public interface IVaccinationRepository
    {
        ICollection<Vaccination> GetVaccinations();
        bool VaccinationExists(int id);
        Vaccination GetVaccination(int id);
        bool CreateVaccination(Vaccination Vaccination);
        bool DeleteVaccination(Vaccination Vaccination);
        bool UpdateVaccination(Vaccination Vaccination);
        bool Save();
    }
}
