using SmokeQuit.Repositories.AnVT.DTOs;
using SmokeQuit.Repositories.AnVT.ModelExtensions;
using SmokeQuit.Repositories.AnVT.Models;
using SmokeQuit.Services.AnVT;

namespace SmokeQuit.GraphQLAPIServices.AnVT.GraphQLs
{
	public class BlogPostsAnVTQueries
	{
		private readonly IServiceProvider _serviceProvider;

		public BlogPostsAnVTQueries(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task<List<BlogPostsAnVt>> GetAllAsync()
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.GetAllAsync();
		}

		public async Task<PagedResult<BlogPostsAnVt>> GetAllWithPagingAsync(int pageNumber, int pageSize)
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.GetAllWithPagingAsync(pageNumber, pageSize);
		}

		public async Task<BlogPostsAnVt> GetByIdAsync(int code)
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.GetByIdAsync(code);
		}

		public async Task<List<BlogPostsAnVt>> SearchAsync(int? planId = null, string title = null, string category = null, string tags = null, bool? isPublic = null)
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.SearchAsync(planId, title, category, tags, isPublic);
		}

		public async Task<PagedResult<BlogPostsAnVt>> SearchWithPagingAsync(BlogPostSearchRequest request)
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.SearchWithPagingAsync(request);
		}

		public async Task<int> CreateAsync(BlogPostsAnVtDto blogPost)
		{
			var blogPostsAnVTService = _serviceProvider.GetRequiredService<IBlogPostsAnVTService>();
			return await blogPostsAnVTService.CreateAsync(blogPost);
		}
	}
}
