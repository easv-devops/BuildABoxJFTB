using Dapper;
using Infrastructure.Model;
using Npgsql;

namespace Infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public Box CreateBox(string title, string description, decimal price, string imageUrl,
        decimal length, decimal width, decimal height)
    {
        var sql =
            $@"
            insert into buildabox.box (title, description, price, imageurl, width, length, height) 
            values (@title, @description, @price, @imageUrl, @length, @width, @height) 
            returning *;
            ";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new { title, description, price, imageUrl, width, length, height });
        }
    }

    public IEnumerable<Box> GetAllProducts()
    {
        var sql = $@"select * from buildabox.box;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }

    public Box GetBoxById(int id)
    {
        var sql = 
            $@"
            select * from buildabox.box
            where productid = @productid;
            ";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, id);
        }
    }
    
    
    public bool DeleteBox(int id)
    {
        var sql = @"DELETE FROM buildabox.box
                    WHERE productid = @productid";
        using (var conn = _dataSource.OpenConnection())
        {
            var rowsAffected = conn.Execute(sql, new {id}) == 1;
            return rowsAffected;
        }
    }
    
    
    public Box UpdateBox(Box box)
    {
        var sql = @"UPDATE buildabox.box
                    SET title = @Title,
                        description = @Description,
                        price = @Price,
                        imageurl = @ImageURL,
                        length = @Length,
                        width = @Width,
                        height = @Height
                    WHERE productid = @ProductId
                    RETURNING *;";   
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, box);
        }
    }
}