using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PeblitAPI.Application.PeblitItemCommand
{
    public record AlterarRoupaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int IdRoupaAtual { get; set; }
        public int IdFundoAtual { get; set; }
    }

    public class AlterarRoupaCommandHandler : IRequestHandler<AlterarRoupaCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AlterarRoupaCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AlterarRoupaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PeblitItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(PeblitItem));
            }

            entity.IdRoupaAtual = request.IdRoupaAtual;
            entity.IdFundoAtual = request.IdFundoAtual;

            _context.PeblitItems.Update(entity);



            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
