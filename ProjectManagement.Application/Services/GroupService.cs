using ProjectManagement.Application.Interfaces;
using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Services
{
    public sealed class GroupService : IGroupService
    {
        private readonly IDbContext _dbContext;

        public GroupService(IDbContext dbContext)
            => _dbContext = dbContext;

        public Group Create(string title, Guid boardId)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),
                Title = title,
                BoardId = boardId
            };

            _ = this._dbContext.Groups.Add(group);
            _ = this._dbContext.SaveChangesAsync();

            return group;
        }

        public void DeleteGroup(Guid id)
        {
            var group = this._dbContext.Groups.SingleOrDefault(g => g.Id == id)
                ?? throw new NullReferenceException();

            this._dbContext.Groups.Remove(group);
            this._dbContext.SaveChangesAsync();
        }

        public List<Group> GetAllGroups()
        {
            return _dbContext.Groups.ToList();
        }

        public Group GetGroupById(Guid id)
        {
            var group = this._dbContext.Groups.SingleOrDefault(g => g.Id == id)
                ?? throw new NullReferenceException();

            return group;
        }

        public Group UpdateGroup(Guid id, Cards card)
        {
            var group = this._dbContext.Groups.SingleOrDefault(g => g.Id == id)
                ?? throw new NullReferenceException();

            group.Cards.Add(card);

            return group;
        }
    }
}
