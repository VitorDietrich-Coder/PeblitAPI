using CleanArchitecture.Application.Common.Interfaces;
using PeblitAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeblitAPI.Application.PeblitItemCommand
{
    public record ListarParametrosCommand : IRequest<PeblitItem>
    {
        public int Id { get; set; }
    }

    public class ListarParametrosCommandHandler : IRequestHandler<ListarParametrosCommand, PeblitItem>
    {
        private readonly IApplicationDbContext _context;

        public ListarParametrosCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PeblitItem> Handle(ListarParametrosCommand request, CancellationToken cancellationToken)
        {
           var query =  _context.PeblitItems.Where(x => x.Id == request.Id).FirstOrDefault();

            var entity = new PeblitItem()
            {
                Id = query.Id,
                IdFundoAtual = query.IdFundoAtual,
                IdRoupaAtual = query.IdRoupaAtual,
                NomePlanta = query.NomePlanta,
                Luminosidade = query.Luminosidade,
                Pontos = query.Pontos,
                Temperatura = query.Temperatura,
                Umidade = query.Umidade,
                UmidadeSolo = query.UmidadeSolo,
            };

            return entity;
        }
    }
}
