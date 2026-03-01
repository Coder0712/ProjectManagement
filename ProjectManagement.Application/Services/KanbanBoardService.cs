using ProjectManagement.Domain.Boards;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Application.Services
{
    /// <summary>
    /// The kanban board service.
    /// </summary>
    public sealed class Boardervice
    {

        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// Initialize a new object of type <see cref="Boardervice"/>.>
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public Boardervice(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public void DeleteBoard(Guid id, CancellationToken cancellationToken = default)
        {
            var kanbanBoard = _dbContext.Board.SingleOrDefault(p => p.Id == id)
                ?? throw new NullReferenceException();

            _dbContext.Board.Remove(kanbanBoard);
            _dbContext.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc />
        public Board GetBoard(Guid id)
        {
            var kanbanBoard = _dbContext.Board.SingleOrDefault(p => p.Id == id);

            return kanbanBoard is null
                ? throw new NullReferenceException()
                : kanbanBoard;
        }

        /// <inheritdoc />
        public List<Board> GetBoards()
        {
            return _dbContext.Board.ToList();
        }
    }
}
