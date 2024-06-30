using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeblitAPI.Application.PeblitItemCommand
{
    public record ListarTodosParametrosCommand : IRequest<IEnumerable<PeblitItem>>
    {
        public int Id { get; set; }
    }

    public class ListarTodosParametrosCommandHandler : IRequestHandler<ListarTodosParametrosCommand, IEnumerable<PeblitItem>>
    {
        private readonly IApplicationDbContext _context;

        public ListarTodosParametrosCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PeblitItem>> Handle(ListarTodosParametrosCommand request, CancellationToken cancellationToken)
        {
            var query = _context.PeblitItems.ToList();

            return query;
        }
    }
}
