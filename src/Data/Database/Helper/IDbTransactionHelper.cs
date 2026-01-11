using System.Data.Common;

namespace Comaagora_API.Data;

public interface IDbTransactionHelper
{
    public Task<DbTransaction> BeginTransactionAsync();
    public Task CommitTransactionAsync();
    public Task RollbackTransactionAsync();
  
}