using Infrastructure;
using Infrastructure.Model;

namespace Service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public Box CreateBox(string title, string description, decimal price, string imageUrl, decimal length,
        decimal width, decimal height)
    {
        return _repository.CreateBox(title, description, price, imageUrl, length, width, height);
    }

    public IEnumerable<Box> GetAllProducts()
    {
        return _repository.GetAllProducts();
    }
}
