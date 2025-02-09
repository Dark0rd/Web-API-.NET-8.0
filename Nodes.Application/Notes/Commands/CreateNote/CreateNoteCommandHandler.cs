using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.interfaces;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommands, Guid>
    {
        private readonly INotesDbContext dbContext;
        public CreateNoteCommandHandler(INotesDbContext dbContext) => dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommands request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null

            };

           await dbContext.Notes.AddAsync(note, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return note.Id;
            
        }
    }
}
