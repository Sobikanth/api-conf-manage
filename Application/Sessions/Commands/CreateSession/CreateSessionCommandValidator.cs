using Application.Common.Interfaces;

using FluentValidation;

namespace Application.Sessions.Commands.CreateSession;

public class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
{
    public CreateSessionCommandValidator(IApplicationDbContext context)
    {
        RuleFor(x => x.Topic)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(x => x.ConfDate)
            .NotEmpty()
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Conference date must be in the future"); RuleFor(x => x.StartTime)
            .NotEmpty()
            .LessThan(x => x.EndTime)
            .LessThan(new TimeOnly(23, 59));
        RuleFor(x => x.EndTime)
            .NotEmpty()
            .GreaterThan(x => x.StartTime)
            .WithMessage("End time must be greater than start time")
            .LessThan(new TimeOnly(23, 59))
            .WithMessage("End time must be less than 23:59");
        RuleFor(x => x.SpeakerId)
            .NotEqual(Guid.Empty)
            .WithMessage("Speaker must be selected")
            .MustAsync(async (speakerId, cancellationToken) =>
            {
                return await context.Speakers.FindAsync([speakerId], cancellationToken: cancellationToken) != null;
            })
            .WithMessage("Speaker does not exist");
        RuleFor(x => x.RoomId)
            .NotEqual(Guid.Empty)
            .WithMessage("Room must be selected")
            .MustAsync(async (roomId, cancellationToken) =>
            {
                return await context.Rooms.FindAsync([roomId], cancellationToken: cancellationToken) != null;
            })
            .WithMessage("Room does not exist");
    }
}