using System.ComponentModel.DataAnnotations;

namespace AppointmentMicroservice.Model.Dtos
{
    public class VaccinationDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
