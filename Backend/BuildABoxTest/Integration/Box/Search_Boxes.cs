namespace BuildABoxTest.Integration.Box;

public class Search_Boxes
{
    /**
     * TO DO:
     *
     * 1. Filtreres boxes væk ud fra søgetekst titel
     * 2. Sendes rigtige mængde resultater tilbage
     * 3. Test at man kan søge på:
     * a) ID
     * b) Titel
     * c) Beskrivelse
     * d) osv. osv. osv...
     * 4. Søg på tomt input og forvent rigtige fejlbeskeder
     *
     */
    
    [SetUp]
    public void Setup()
    {
        Helper.TriggerRebuild();
    }

    [Test]
    public void Dummy()
    {
        
    }
}