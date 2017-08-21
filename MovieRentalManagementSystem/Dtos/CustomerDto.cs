using MovieRentalManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalManagementSystem.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfMember]
        public DateTime? BirthDay { get; set; }
    }
}