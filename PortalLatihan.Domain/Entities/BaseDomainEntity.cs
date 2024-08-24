using System.ComponentModel.DataAnnotations;

namespace PortalLatihan.Domain.Entities
{
    public class BaseDomainEntity
    {
        [Key]
        public Guid ID { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public string? SysUserCreated { get; protected set; }
        public DateTime? SysDateCreated { get; protected set; }
        public string? SysUserModified { get; protected set; }
        public DateTime? SysDateModified { get; protected set; }
        public BaseDomainEntity()
        {
            ID = Guid.NewGuid();
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void CreatedTimeStamp(string user)
        { 
            SysUserCreated = user;
            SysDateCreated = DateTime.Now;
            SysUserModified = user;
            SysDateModified = DateTime.Now;
        }

        public void ModifiedTimeStamp(string user)
        {
            SysUserModified = user;
            SysDateModified = DateTime.Now;
        }
    }
}
