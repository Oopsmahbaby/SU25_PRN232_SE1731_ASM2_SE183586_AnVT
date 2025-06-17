namespace SmokeQuit.Services.AnVT
{
	public interface IServiceProviders
	{
		SystemUserAccountService UserAccountService { get; }
		QuitPlansAnhDtn_AnVTService QuitPlansAnhDtn_AnVTService { get; }
		IBlogPostsAnVTService BlogPostsAnVTService { get; }
	}
	public class ServiceProviders : IServiceProviders
	{
		private SystemUserAccountService _systemUserAccountService;
		private QuitPlansAnhDtn_AnVTService _quitPlansAnhDtn_AnVTService;
		private IBlogPostsAnVTService _blogPostsAnVTService;
		public SystemUserAccountService UserAccountService
		{
			get { return _systemUserAccountService ??= new SystemUserAccountService(); }
		}

		public QuitPlansAnhDtn_AnVTService QuitPlansAnhDtn_AnVTService
		{
			get { return _quitPlansAnhDtn_AnVTService ??= new QuitPlansAnhDtn_AnVTService(); }
		}

		public IBlogPostsAnVTService BlogPostsAnVTService
		{
			get
			{
				return _blogPostsAnVTService ??= new BlogPostsAnVTService();
			}
		}
	}
}
