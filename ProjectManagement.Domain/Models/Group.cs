using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Group
    {
        /// <summary>
        /// Gets or sets the id of the group.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the board id.
        /// </summary>
        public Guid BoardId {  get; set; }

        /// <summary>
        /// Board reference
        /// </summary>
        public KanbanBoard Board { get; set; }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        public ICollection<Cards> Cards { get; set; }

    }
}
