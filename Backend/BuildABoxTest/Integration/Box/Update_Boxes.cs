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