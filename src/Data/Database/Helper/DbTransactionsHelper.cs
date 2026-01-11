using System.Data.Common;
using Comaagora_API.Data.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Comaagora_API.Data;

public class DbTransactionsHelper : IDbTransactionHelper
{
    private readonly AppDbContext _context;

    public DbTransactionsHelper(AppDbContext context)
    {
        _context  = context;
    }
    public async Task<DbTransaction> BeginTransactionAsync()
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        return transaction.GetDbTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}