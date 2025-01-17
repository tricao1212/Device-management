using Device_management_software.Models.Entities;
using Device_management_software.Repostiories.BaseRepository;
using Device_management_software.Repostiories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Device_management_software.Repostiories.Implements
{
    public class CategoryRepository : Repository<Category>, ICategoryRepostiory
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
