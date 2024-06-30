using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeblitAPI.Application.PeblitItemCommand
{
    public record AlterarParametrosCommand : IRequest<int>
    {
        public PeblitItem PeblitItem { get; init; }
    }

    public class AlterarParametrosCommandHandler : IRequestHandler<AlterarParametrosCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AlterarParametrosCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AlterarParametrosCommand request, CancellationToken cancellationToken)
        {
            var entity = new PeblitItem()
            {
                Id = request.PeblitItem.Id,
                IdFundoAtual = request.PeblitItem.IdFundoAtual,
                IdRoupaAtual = request.PeblitItem.IdRoupaAtual,
                NomePlanta = request.PeblitItem.NomePlanta,
                Luminosidade = request.PeblitItem.Luminosidade,
                Pontos = request.PeblitItem.Pontos,
                Temperatura = request.PeblitItem.Temperatura,
                Umidade = request.PeblitItem.Umidade,
                UmidadeSolo = request.PeblitItem.UmidadeSolo,
            };

            _context.PeblitItems.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
