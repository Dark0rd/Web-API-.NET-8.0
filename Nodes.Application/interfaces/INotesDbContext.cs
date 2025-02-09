﻿using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
namespace Notes.Application.interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
