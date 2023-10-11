using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task CreateBox()
    {

        await Page.GotoAsync("http://localhost:4200/");

        await Page.GotoAsync("http://localhost:4200/home");

        await Page.GetByTestId("menu-button").ClickAsync();

        await Page.GetByTestId("create-menu-button").ClickAsync();

        await Page.GetByLabel("title").ClickAsync();

        await Page.GetByLabel("title").FillAsync("Playwright test kasse");

        await Page.GetByLabel("title").PressAsync("Tab");
        
        await Page.GetByLabel("descriptionD").FillAsync("Denne kasse bruges til at teste playwright");

        await Page.GetByLabel("descriptionD").PressAsync("Tab");

        await Page.GetByLabel("Price").FillAsync("99");

        await Page.GetByLabel("Price").PressAsync("Tab");

        await Page.GetByLabel("imageUrl").ClickAsync();

        await Page.GetByLabel("imageUrl").FillAsync("https://www.celladorales.com/wp-content/uploads/2016/12/ShippingBox_sq.jpg");

        await Page.GetByLabel("width").ClickAsync();

        await Page.GetByLabel("width").FillAsync("50");

        await Page.GetByLabel("width").PressAsync("Tab");

        await Page.GetByLabel("length").FillAsync("70");

        await Page.GetByLabel("length").PressAsync("Tab");

        await Page.GetByLabel("height").FillAsync("40");

        await Page.GetByTestId("create-button").ClickAsync();
        
    }
}