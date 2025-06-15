using SmokeQuit.Repositories.AnVT.DBContext;

namespace SmokeQuit.Repositories.AnVT
{
	public interface IUnitOfWork : IDisposable
	{
		SystemUserAccountRepository SystemUserAccountRepository { get; }
		BlogPostsAnVTRepository BlogPostsAnVTRepository { get; }
		QuitPlansAnhDtn_AnVTRepository QuitPlansAnhDtn_AnVTRepository { get; }
		int SaveChangesWithTransaction();
		Task<int> SaveChangesWithTransactionAsync();
	}

	public class UnitOfWork : IUnitOfWork
	{
		private readonly SU25_PRN232_SE1731_G6_SmokeQuitContext _context = new();
		private SystemUserAccountRepository _systemUserAccountRepository;
		private BlogPostsAnVTRepository _blogPostsAnVTRepository;
		private QuitPlansAnhDtn_AnVTRepository _quitPlansAnhDtn_AnVTRepository;

		public UnitOfWork()
		{
			_context ??= new();
		}
		public SystemUserAccountRepository SystemUserAccountRepository
		{
			get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
		}

		public BlogPostsAnVTRepository BlogPostsAnVTRepository
		{
			get { return _blogPostsAnVTRepository ??= new BlogPostsAnVTRepository(_context); }
		}

		public QuitPlansAnhDtn_AnVTRepository QuitPlansAnhDtn_AnVTRepository
		{
			get { return _quitPlansAnhDtn_AnVTRepository ??= new QuitPlansAnhDtn_AnVTRepository(_context); }
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public int SaveChangesWithTransaction()
		{
			int result = -1;

			//System.Data.IsolationLevel.Snapshot
			using (var dbContextTransaction = _context.Database.BeginTransaction())
			{
				try
				{
					result = _context.SaveChanges();
					dbContextTransaction.Commit();
				}
				catch (Exception)
				{
					//Log Exception Handling message                      
					result = -1;
					dbContextTransaction.Rollback();
				}
			}

			return result;
		}

		public async Task<int> SaveChangesWithTransactionAsync()
		{
			int result = -1;

			//System.Data.IsolationLevel.Snapshot
			using (var dbContextTransaction = _context.Database.BeginTransaction())
			{
				try
				{
					result = await _context.SaveChangesAsync();
					dbContextTransaction.Commit();
				}
				catch (Exception)
				{
					//Log Exception Handling message                      
					result = -1;
					dbContextTransaction.Rollback();
				}
			}

			return result;
		}
	}
}
