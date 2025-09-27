using Abp.Domain.Entities.Auditing;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.Domain.Organisations;
using Nthware.SDS.Domain.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nthware.SDS.Domain.Technicians
{
    public class Technician : FullAuditedEntity<long>
    {
        public string EmployeeNo { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Speciality { get; set; }

        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public long? OrganisationId { get; set; }
        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }

        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        public Technician()
        {
            AssignedTickets = new List<Ticket>();
        }
    }
}
