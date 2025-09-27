using Abp.Domain.Entities.Auditing;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.Domain.Technicians;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nthware.SDS.Domain.Organisations
{
    public class Organisation : FullAuditedEntity<long>
    {
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual string Type { get; set; }
        public virtual ICollection<Technician> Technicians { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Organisation()
        {
            Technicians = new List<Technician>();
            Users = new List<User>();
        }
    }
}
