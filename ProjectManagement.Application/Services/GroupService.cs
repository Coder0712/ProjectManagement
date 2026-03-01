using ProjectManagement.Domain.Boards;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Application.Services
{
    public sealed class Groupervice
    {
        private readonly IDbContext _dbContext;

        public Groupervice(IDbContext dbContext)
            => _dbContext = dbContext;


        public void DeleteGroup(Guid id)
        {
            var group = this._dbContext.Group.SingleOrDefault(g => g.Id == id)
                ?? throw new NullReferenceException();

            this._dbContext.Group.Remove(group);
            this._dbContext.SaveChangesAsync();
        }

        public List<Group> GetAllGroup()
        {
            return _dbContext.Group.ToList();
        }

        public Group GetGroupById(Guid id)
        {
            var group = this._dbContext.Group.SingleOrDefault(g => g.Id == id)
                ?? throw new NullReferenceException();

            return group;
        }
    }
}
