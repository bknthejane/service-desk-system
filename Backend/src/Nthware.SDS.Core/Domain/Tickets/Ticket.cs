using Abp.Domain.Entities.Auditing;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.Domain.Technicians;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nthware.SDS.Domain.Tickets
{
    public class Ticket : FullAuditedEntity<long>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; } = "Open";
        public virtual string Priority { get; set; } = "Medium";
        public virtual string Category { get; set; }
        public long? RaisedById { get; set; }
        [ForeignKey("RaisedById")]
        public virtual User RaisedBy { get; set; }

        public long? AssignedTechnicianId { get; set; }
        [ForeignKey("AssignedTechnicianId")]
        public virtual Technician AssignedTechnician { get; set; }
    }
}
