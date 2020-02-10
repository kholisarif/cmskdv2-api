using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Bank
{
  public class BankCommandHandlers :
    IRequestHandler<BankCreate, Models.Entities.Bank>,
    IRequestHandler<BankUpdate, Models.Entities.Bank>,
    IRequestHandler<BankDelete>, IRequestHandler<BankBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BankCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Bank> Handle(BankCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Bank>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Bank> Handle(BankUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Bank.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BankDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.Bank.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BankBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Bank
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}