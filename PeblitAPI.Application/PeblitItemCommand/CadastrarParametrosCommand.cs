using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;

namespace PeblitAPI.Application.PeblitItemCommand
{

    public class CadastrarParametrosCommand : IRequest<int>
    {
        public PeblitItem? PeblitItem { get; init; }
    }

    public class CadastrarParametrosCommandHandler : IRequestHandler<CadastrarParametrosCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CadastrarParametrosCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CadastrarParametrosCommand request, CancellationToken cancellationToken)
        {
            var entity = new PeblitItem()
            {
                IdFundoAtual = request.PeblitItem.IdFundoAtual,
                IdRoupaAtual = request.PeblitItem.IdRoupaAtual,
                NomePlanta = request.PeblitItem.NomePlanta,
                Luminosidade = request.PeblitItem.Luminosidade,
                Pontos = request.PeblitItem.Pontos,
                Temperatura = request.PeblitItem.Temperatura,
                Umidade = request.PeblitItem.Umidade,
                UmidadeSolo = request.PeblitItem.UmidadeSolo,
            };

            _context.PeblitItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
