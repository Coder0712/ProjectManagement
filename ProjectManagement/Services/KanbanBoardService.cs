using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    public sealed class KanbanBoardService : IKanbanBoardService
    {
        private List<KanbanBoard> _kanbanBoards = [];
        public KanbanBoard CreateBoard(string name)
        {
            var kanbanBoard = new KanbanBoard
            {
                Id = Guid.NewGuid(),
                Name = name,
            };

            _kanbanBoards.Add(kanbanBoard);

            return kanbanBoard;
        }

        public void DeleteBoard(Guid id)
        {
            var kanbanBoard = _kanbanBoards.SingleOrDefault(p => p.Id == id)
                ?? throw new NullReferenceException();

            this._kanbanBoards.Remove(kanbanBoard);
        }

        public KanbanBoard GetBoard(Guid id)
        {
            var kanbanBoard = _kanbanBoards.SingleOrDefault(p => p.Id == id);

            return kanbanBoard is null
                ? throw new NullReferenceException()
                : kanbanBoard;
        }

        public List<KanbanBoard> GetBoards()
        {
            return _kanbanBoards;
        }

        public KanbanBoard UpdateBoard(Guid id, string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            var project = _kanbanBoards.SingleOrDefault(p => p.Id == id)
                ?? throw new NullReferenceException();

            project.Name = name;

            return project;
        }
    }
}
