namespace BuildABoxTest.Integration.Box;

public class Create_Boxes
{
    /**
     * TO DO:
     *
     * 1. Instantier, sæt ind, tjek om den er i db (Test cases med korrekt og forkert input)
     * a) Uden titel
     * b) For lang titel
     * c) bogstaver i talfelt
     * d) korrekt data
     *
     * 2. Lav en duplicate (samme titel bør blocke creation?)
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