namespace KBS.CreditAppSys.Application.Features.BaseRules;

public abstract class BaseBusinessRules
{
    protected internal virtual Task<bool> IsDataAvailable<TCommand>(TCommand command)
        => Task.FromResult(false);
}