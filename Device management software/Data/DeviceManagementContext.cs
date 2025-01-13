using Device_management_software.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Device_management_software.Data
{
    public class DeviceManagementContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeviceManagementContext(DbContextOptions<DeviceManagementContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var auditableEntity = (BaseEntity)entry.Entity;
                var currentTime = DateTime.Now;
                var currentUsername = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";
                if (entry.State == EntityState.Added)
                {
                    auditableEntity.CreatedAt = currentTime;
                    auditableEntity.CreatedBy = currentUsername;
                }

                auditableEntity.UpdatedAt = currentTime;
                auditableEntity.UpdatedBy = currentUsername;
            }
        }
    }
}
