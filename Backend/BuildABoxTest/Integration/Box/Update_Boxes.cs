using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BuildABoxTest.Integration.Box;

public class Update_Boxes
{
    /**
     * TO DO:
     *
     * 1. Lav en, ændr, tjek at det er updated
     * 2. Ændr titel til en allerede eksisterende titel
     * 3. Ændr til forkert valideret input (str./pris til negativ, titel til for kort)
     * 4. 
     * 
     */
    private HttpClient _httpClient;
    
    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        Helper.TriggerRebuild();
    }

    [Test]
    public async Task EditBoxWithValidInput()
    {
        Infrastructure.Model.Box box = new Infrastructure.Model.Box()
        {
            ProductID = 1,
            Title = "Created title",
            Description = "Description",
            Price = 14,
            ImageURL = "https://www.celladorales.com/wp-content/uploads/2016/12/ShippingBox_sq.jpg",
            Length = 4,
            Width = 4,
            Height = 2
        };

        string urlCreate = "http://localhost:5000/api/createBox";//todo first part should be a global variable, so we can set it to the domain in future
        HttpResponseMessage responseCreate;
        
        string urlUpdate = "http://localhost:5000/api/products";
        HttpResponseMessage responseUpdate;
        
        Infrastructure.Model.Box? responseBoxCreated;
        Infrastructure.Model.Box? responseBoxUpdated;
        try
        {
            responseCreate = await _httpClient.PostAsJsonAsync(urlCreate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseCreate.Content.ReadAsStringAsync());
            
            box.Title = "Edited title";

            responseUpdate = await _httpClient.PutAsJsonAsync(urlUpdate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseUpdate.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Helper.NoResponseMessage, e);
        }

        using (new AssertionScope())
        {
            responseBoxCreated = responseCreate.Content.ReadFromJsonAsync<Infrastructure.Model.Box>().Result;
            responseBoxUpdated = responseUpdate.Content.ReadFromJsonAsync<Infrastructure.Model.Box>().Result;
            responseUpdate.IsSuccessStatusCode.Should().BeTrue();
            responseBoxUpdated.Should().NotBeNull();
            responseBoxUpdated?.Title.Equals(box.Title).Should().BeTrue();
            responseBoxUpdated.Title.Equals(responseBoxCreated?.Title).Should().BeFalse();
        }
    }
    
    [Test]
    public async Task EditBoxWithInvalidTitle()
    {
        Infrastructure.Model.Box box = new Infrastructure.Model.Box()
        {
            ProductID = 1,
            Title = "Created title",
            Description = "Description",
            Price = 14,
            ImageURL = "https://www.celladorales.com/wp-content/uploads/2016/12/ShippingBox_sq.jpg",
            Length = 4,
            Width = 4,
            Height = 2
        };

        string urlCreate = "http://localhost:5000/api/createBox";//todo first part should be a global variable, so we can set it to the domain in future
        HttpResponseMessage responseCreate;
        
        string urlUpdate = "http://localhost:5000/api/products";
        HttpResponseMessage responseUpdate;
        
        Infrastructure.Model.Box? responseBoxUpdated;
        try
        {
            responseCreate = await _httpClient.PostAsJsonAsync(urlCreate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseCreate.Content.ReadAsStringAsync());
            
            box.Title = "To"; //Title is too short, must be at least three characters

            responseUpdate = await _httpClient.PutAsJsonAsync(urlUpdate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseUpdate.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Helper.NoResponseMessage, e);
        }

        using (new AssertionScope())
        {
            responseBoxUpdated = responseUpdate.Content.ReadFromJsonAsync<Infrastructure.Model.Box>().Result;
            responseUpdate.IsSuccessStatusCode.Should().BeFalse();
            responseUpdate.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseBoxUpdated.Should().NotBeNull();
            responseBoxUpdated?.Title.Equals(box.Title).Should().BeFalse();
        }
    }
    
    /**
    [TestCase("", 40, 13, 15, 20, TestName = "EmptyTitle")]
    [TestCase("Four", 40, 13, 15, 20, TestName = "TooShortTitle")]
    [TestCase("Mock Title", -10, 13, 15, 20, TestName = "NegativePrice")]
    [TestCase("Mock Title", 40, -10, 15, 20, TestName = "NegativeLength")]
    [TestCase("Mock Title", 40, 13,  -10, 20, TestName = "NegativeWidth")]
    [TestCase("Mock Title", 40, 13, 15, -10, TestName = "NegativeHeight")]
    public async Task EditBoxWithInvalidInput(string title, decimal price, double length, double width, double height)
    {
        Infrastructure.Model.Box box = new Infrastructure.Model.Box()
        {
            ProductID = 1,
            Title = title,
            Description = "Description",
            Price = price,
            ImageURL = "https://www.celladorales.com/wp-content/uploads/2016/12/ShippingBox_sq.jpg",
            Length = length,
            Width = width,
            Height = height
        };

        string urlCreate = "http://localhost:5000/api/createBox";//todo first part should be a global variable, so we can set it to the domain in future
        HttpResponseMessage responseCreate;
        
        string urlUpdate = "http://localhost:5000/api/products";
        HttpResponseMessage responseUpdate;
        
        Infrastructure.Model.Box? responseBoxCreated;
        Infrastructure.Model.Box? responseBoxUpdated;
        try
        {
            responseCreate = await _httpClient.PostAsJsonAsync(urlCreate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseCreate.Content.ReadAsStringAsync());
            
            box.Title = "Edited title";

            responseUpdate = await _httpClient.PutAsJsonAsync(urlUpdate, box);
            TestContext.WriteLine("The full body response: " 
                                  + await responseUpdate.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Helper.NoResponseMessage, e);
        }

        using (new AssertionScope())
        {
            responseBoxCreated = responseCreate.Content.ReadFromJsonAsync<Infrastructure.Model.Box>().Result;
            responseBoxUpdated = responseUpdate.Content.ReadFromJsonAsync<Infrastructure.Model.Box>().Result;
            responseUpdate.IsSuccessStatusCode.Should().BeTrue();
            responseBoxUpdated.Should().NotBeNull();
            responseBoxUpdated?.Title.Equals(box.Title).Should().BeTrue();
            responseBoxUpdated.Title.Equals(responseBoxCreated?.Title).Should().BeFalse();
        }
    }
    */
}