namespace ColoradoGroupEvaluation.Infra.Base.Database.Uow;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}