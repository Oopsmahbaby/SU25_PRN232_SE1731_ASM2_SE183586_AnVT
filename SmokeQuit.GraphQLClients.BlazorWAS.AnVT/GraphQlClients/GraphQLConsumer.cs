using GraphQL.Client.Abstractions;
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
			var query = "";

			var response = await _graphQLClient.SendQueryAsync<BlogPostsAnVtGraphQLResponse>(query);
			var result = response?.Data?.BlogPostsAnVts;

			return result;
		}
	}
}
