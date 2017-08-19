using MovieRentalManagementSystem.Models;
using System.Collections.Generic;

namespace MovieRentalManagementSystem.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}