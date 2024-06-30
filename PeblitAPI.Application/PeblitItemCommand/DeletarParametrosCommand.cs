using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeblitAPI.Application.PeblitItemCommand
{
    public record DeletarParametrosCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeletarParametrosCommandHandler : IRequestHandler<DeletarParametrosCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeletarParametrosCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletarParametrosCommand request, CancellationToken cancellationToken)
        {
           var query =  _context.PeblitItems.Where(x => x.Id == request.Id).FirstOrDefault();

            _context.PeblitItems.Remove(query);

            await _context.SaveChangesAsync(cancellationToken);

            return true; 
        }
    }
}
