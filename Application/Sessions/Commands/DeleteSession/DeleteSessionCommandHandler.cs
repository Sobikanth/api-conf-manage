
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Ardalis.GuardClauses;

namespace Application.Sessions.Commands.DeleteSession;

public record DeleteSessionCommand(Guid Id) : IRequest;

public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSessionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Sessions
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Sessions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}