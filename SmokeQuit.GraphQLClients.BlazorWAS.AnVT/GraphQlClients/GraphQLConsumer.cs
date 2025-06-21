using GraphQL;
using GraphQL.Client.Abstractions;
using SmokeQuit.GraphQLClients.BlazorWAS.AnVT.DTOs;
using SmokeQuit.GraphQLClients.BlazorWAS.AnVT.Models;

namespace SmokeQuit.GraphQLClients.BlazorWAS.AnVT.GraphQlClients
{
	public class GraphQLConsumer
	{
		private readonly IGraphQLClient _graphQLClient;

		public GraphQLConsumer(IGraphQLClient graphQLClient)
		{
			_graphQLClient = graphQLClient;
		}

		public async Task<List<BlogPostsAnVt>> GetBlogPosts()
		{
			var query = @"
			query query1 {
				all {
					blogPostsAnVtid
					category
					tags
					createdAt
					title
					user {
						userName
					}
				}
			}";

			try
			{
			var response = await _graphQLClient.SendQueryAsync<BlogPostsAnVtGraphQLResponse>(query);

			var result = response?.Data?.All;
				return result;

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<BlogPostsAnVt>();
		}

		public async Task<BlogPostsAnVt> GetBlogPostById(int id)
		{
			var query = @"
			query query1($id: Int!) {
				blogPostsAnVt(blogPostsAnVtid: $id) {
					blogPostsAnVtid
					category
					tags
					createdAt
					title
					user {
						userName
					}
				}
			}";
			try
			{
				var response = await _graphQLClient.SendQueryAsync<BlogPostsAnVtGraphQLResponse>(query, new { id });
				return response?.Data?.All?.FirstOrDefault();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}


		public async Task<int?> CreateBlogPost(BlogPostsAnVt post)
		{
			var mutation = @"
		mutation CreateBlogPost($input: BlogPostsAnVtDtoInput!) {
			createBlogPost(blogPostsAnVtDto: $input)
		}";

			var variables = new
			{
				input = new
				{
					userId = post.UserId,
					planId = post.PlanId,
					title = post.Title,
					content = post.Content,
					category = post.Category,
					tags = post.Tags,
					isPublic = post.IsPublic,
					viewsCount = post.ViewsCount,
					likesCount = post.LikesCount,
					commentsCount = post.CommentsCount,
					createdAt = post.CreatedAt,
					updatedAt = post.UpdatedAt
				}
			};

			try
			{
				var request = new GraphQLRequest
				{
					Query = mutation,
					Variables = new { input = variables.input }
				};

				var response = await _graphQLClient.SendMutationAsync<GraphQLResponseWrapper>(request);
				return response.Data?.CreateBlogPost;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"GraphQL createBlogPost error: {ex.Message}");
				return null;
			}
		}


	}
}
