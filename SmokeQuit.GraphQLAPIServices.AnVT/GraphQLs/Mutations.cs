using SmokeQuit.Repositories.AnVT.DTOs;
using SmokeQuit.Services.AnVT;

namespace SmokeQuit.GraphQLAPIServices.AnVT.GraphQLs
{
	public class Mutations
	{
		private readonly IServiceProviders _serviceProvider;
		public Mutations(IServiceProviders serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task<int> CreateBlogPost(BlogPostsAnVtDto blogPostsAnVtDto)
		{
			return await _serviceProvider.BlogPostsAnVTService.CreateAsync(blogPostsAnVtDto);
		}

		public async Task<int> UpdateAsync(BlogPostsAnVtDto blogPost)
		{
			return await _serviceProvider.BlogPostsAnVTService.UpdateAsync(blogPost);
		}

		public async Task<bool> DeleteAsync(int code)
		{
			return await _serviceProvider.BlogPostsAnVTService.DeleteAsync(code);
		}
	}
}
