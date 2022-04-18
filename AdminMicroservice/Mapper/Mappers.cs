
using AdminMicroservice.Model;
using AppointmentMicroservice.Model.Dtos;
using AutoMapper;

namespace AdminMicroservice.Mapper
{
    public class Mappers:Profile
    {
        public Mappers()
        {
           CreateMap<Vaccination, VaccinationDto>().ReverseMap();
        }
    }
}
