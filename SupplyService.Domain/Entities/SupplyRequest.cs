using Microsoft.AspNetCore.Identity;
using SupplyService.DomainShared.Enums;

namespace SupplyService.Domain.Entities
{
    public class SupplyRequest : Aggreagate<string>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }
        public IdentityUser User { get; set; }
        public SupplyRequestDepartment Department { get; private set; }

        private SupplyRequest()
        {
            
        }

        public SupplyRequest(string title, string description , string userId , SupplyRequestDepartment supplyRequestDepartment)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            UserId = userId;
            Department = supplyRequestDepartment;
        }

        public void EditSupplyRequest(string title, string description, SupplyRequestDepartment supplyRequestDepartment)
        {
            Title = title;
            Description = description;
            Department = supplyRequestDepartment;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
