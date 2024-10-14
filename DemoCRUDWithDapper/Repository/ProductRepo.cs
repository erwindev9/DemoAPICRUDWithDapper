using Dapper;
using DemoCRUDWithDapper.Interface;
using DemoCRUDWithDapper.Models;
using System.Data;

namespace DemoCRUDWithDapper.Repository
{
    public class ProductRepo(IDbConnection _dbConnection) : IProduct
    {
        public async Task<int> AddProductsAsync(Product product)
        {
            var query = "INSERT INTO Products (Name, Price) Values (@Name, @Price)";
            return await _dbConnection.ExecuteAsync(query,product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(query, new {Id = id});
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var query = "SELECT * FROM Products";
            return await _dbConnection.QueryAsync<Product>(query);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var query = "UPDATE Products SET Name = @Name, Price = @Price Where Id = @Id";
            return await _dbConnection.ExecuteAsync(query, product);
        }
    }
}
