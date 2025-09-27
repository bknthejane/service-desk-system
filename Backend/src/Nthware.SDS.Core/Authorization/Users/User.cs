using Abp.Authorization.Users;
using Abp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nthware.SDS.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public long? AssignedOrganisationId { get; set; }
        [ForeignKey("AssignedOrganisationId")]
        public virtual Domain.Organisations.Organisation AssignedOrganisation { get; set; }

        public virtual ICollection<Domain.Tickets.Ticket> TicketsRaised { get; set; }

        public User()
        {
            TicketsRaised = new List<Domain.Tickets.Ticket>();
        }
    }
}
