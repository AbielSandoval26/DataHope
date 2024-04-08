using Cosmonaut;
using LibraryDataModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace DataHope.Data
{
    public class BlogService
    {
        public readonly ICosmosStore<BlogModel> _blogStore;

        public BlogService(ICosmosStore<BlogModel> blogStore)
        {
            _blogStore = blogStore;
        }

        public async Task<Cosmonaut.Response.CosmosResponse<BlogModel>> AddBlog(BlogModel blog)
        {
            var result = await _blogStore.AddAsync(blog);
            return result;
        }

        public async Task<IEnumerable<BlogModel>> GetBlogs()
        {
            string sql = "SELECT * FROM c WHERE c.CosmosEntityName = @CosmosEntityName";
            try
            {
                var result = await _blogStore.QueryMultipleAsync<BlogModel>(sql, new { CosmosEntityName = "blog" }, new Microsoft.Azure.Documents.Client.FeedOptions { EnableCrossPartitionQuery = true});
                return result;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return Enumerable.Empty<BlogModel>();
            }
        }

        public async Task<BlogModel> BlogByID(string id)
        {
            string sql = "SELECT * FROM c WHERE c.id = @Id";

            try
            {
                var result = await _blogStore.QuerySingleAsync<BlogModel>(sql, new { Id = id }, new Microsoft.Azure.Documents.Client.FeedOptions { EnableCrossPartitionQuery = true });
                return result;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return new BlogModel();
            }
        }

        public async Task<Cosmonaut.Response.CosmosResponse<BlogModel>> DeleteBlog(string id)
        {
            var result = await _blogStore.RemoveByIdAsync(id);
            return result;
        }

    }
}
