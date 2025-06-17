using SmokeQuit.Repositories.AnVT;
using SmokeQuit.Repositories.AnVT.DTOs;
using SmokeQuit.Repositories.AnVT.ModelExtensions;
using SmokeQuit.Repositories.AnVT.Models;

namespace SmokeQuit.Services.AnVT
{
	public interface IBlogPostsAnVTService
	{
		Task<List<BlogPostsAnVt>> GetAllAsync();
		Task<PagedResult<BlogPostsAnVt>> GetAllWithPagingAsync(int pageNumber, int pageSize);
		Task<BlogPostsAnVt> GetByIdAsync(int code);
		Task<List<BlogPostsAnVt>> SearchAsync(int? planId = null, string title = null, string category = null, string tags = null, bool? isPublic = null);
		Task<PagedResult<BlogPostsAnVt>> SearchWithPagingAsync(BlogPostSearchRequest request);
		Task<int> CreateAsync(BlogPostsAnVtDto blogPost);
		Task<int> UpdateAsync(BlogPostsAnVtDto blogPost);
		Task<bool> DeleteAsync(int code);
	}
	public class BlogPostsAnVTService : IBlogPostsAnVTService
	{
		private readonly BlogPostsAnVTRepository _blogPostsAnVTRepository;
		private readonly IUnitOfWork _unitOfWork;

		public BlogPostsAnVTService()
		{
			_blogPostsAnVTRepository ??= new BlogPostsAnVTRepository();
			_unitOfWork ??= new UnitOfWork();
		}

		public BlogPostsAnVTService(BlogPostsAnVTRepository blogPostsAnVTRepository, IUnitOfWork unitOfWork)
		{
			_blogPostsAnVTRepository = blogPostsAnVTRepository;
			_unitOfWork = unitOfWork;
		}

		public Task<int> CreateAsync(BlogPostsAnVtDto blogPost)
		{
			var entities = new BlogPostsAnVt
			{
				UserId = blogPost.UserId,
				PlanId = blogPost.PlanId,
				Title = blogPost.Title,
				Content = blogPost.Content,
				Category = blogPost.Category,
				Tags = blogPost.Tags,
				IsPublic = blogPost.IsPublic,
				CreatedAt = DateTime.Now,
				UpdatedAt = null,
			};
			//return _blogPostsAnVTRepository.CreateAsync(entities);
			return _unitOfWork.BlogPostsAnVTRepository.CreateAsync(entities);
		}

		public async Task<bool> DeleteAsync(int code)
		{
			var blogPost = await _blogPostsAnVTRepository.GetByIdAsync(code);
			if (blogPost != null)
			{
				//return await _blogPostsAnVTRepository.RemoveAsync(blogPost);
				return await _unitOfWork.BlogPostsAnVTRepository.RemoveAsync(blogPost);
			}

			return false;
		}

		public async Task<PagedResult<BlogPostsAnVt>> GetAllWithPagingAsync(int pageNumber, int pageSize)
		{
			//return await _blogPostsAnVTRepository.GetAllWithPagingAsync(pageNumber, pageSize);
			return await _unitOfWork.BlogPostsAnVTRepository.GetAllWithPagingAsync(pageNumber, pageSize);
		}

		public async Task<List<BlogPostsAnVt>> GetAllAsync()
		{
			//return await _blogPostsAnVTRepository.GetAllWithAsync();
			return await _unitOfWork.BlogPostsAnVTRepository.GetAllWithAsync();
		}

		public async Task<BlogPostsAnVt> GetByIdAsync(int code)
		{
			//return await _blogPostsAnVTRepository.GetByIdAsync(code);
			return await _unitOfWork.BlogPostsAnVTRepository.GetByIdAsync(code);
		}

		public async Task<List<BlogPostsAnVt>> SearchAsync(int? planId = null, string title = null, string category = null, string tags = null, bool? isPublic = null)
		{
			//return await _blogPostsAnVTRepository.SearchAsync(planId, title, category, tags, isPublic);
			return await _unitOfWork.BlogPostsAnVTRepository.SearchAsync(planId, title, category, tags, isPublic);
		}

		public async Task<int> UpdateAsync(BlogPostsAnVtDto blogPost)
		{
			//return await _blogPostsAnVTRepository.UpdateAsync(blogPost);
			var entities = new BlogPostsAnVt
			{
				UserId = blogPost.UserId,
				PlanId = blogPost.PlanId,
				Title = blogPost.Title,
				Content = blogPost.Content,
				Category = blogPost.Category,
				Tags = blogPost.Tags,
				IsPublic = blogPost.IsPublic,
				CreatedAt = DateTime.Now,
				UpdatedAt = null,
			};

			return await _unitOfWork.BlogPostsAnVTRepository.UpdateAsync(entities);
		}

		public async Task<PagedResult<BlogPostsAnVt>> SearchWithPagingAsync(BlogPostSearchRequest request)
		{
			//return await _blogPostsAnVTRepository.SearchWithPagingAsync(request);
			return await _unitOfWork.BlogPostsAnVTRepository.SearchWithPagingAsync(request);
		}
	}
}
