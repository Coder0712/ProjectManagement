using ProjectManagement.Domain;
using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    /// <summary>
    /// The kanban board service.
    /// </summary>
    public sealed class KanbanBoardService : IKanbanBoardService
    {

        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// Initialize a new object of type <see cref="KanbanBoardService"/>.>
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public KanbanBoardService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public KanbanBoard CreateBoard(string name, CancellationToken cancellationToken = default)
        {
            var kanbanBoard = new KanbanBoard
            {
                Id = Guid.NewGuid(),
                Name = name,
            };

            _dbContext.KanbanBoards.Add(kanbanBoard);
            _dbContext.SaveChangesAsync(cancellationToken);

            return kanbanBoard;
        }

        /// <inheritdoc />
        public void DeleteBoard(Guid id, CancellationToken cancellationToken = default)
        {
            var kanbanBoard = _dbContext.KanbanBoards.SingleOrDefault(p => p.Id == id)
                ?? throw new NullReferenceException();

            _dbContext.KanbanBoards.Remove(kanbanBoard);
            _dbContext.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc />
        public KanbanBoard GetBoard(Guid id)
        {
            var kanbanBoard = _dbContext.KanbanBoards.SingleOrDefault(p => p.Id == id);

            return kanbanBoard is null
                ? throw new NullReferenceException()
                : kanbanBoard;
        }

        /// <inheritdoc />
        public List<KanbanBoard> GetBoards()
        {
            return _dbContext.KanbanBoards.ToList();
        }

        /// <inheritdoc />
        public KanbanBoard UpdateBoard(Guid id, string name, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(name);

            var board = _dbContext.KanbanBoards.SingleOrDefault(p => p.Id == id)
                ?? throw new NullReferenceException();

            board.Name = name;

            _dbContext.KanbanBoards.Update(board);
            _dbContext.SaveChangesAsync(cancellationToken);

            return board;
        }
    }
}
