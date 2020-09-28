/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/


public interface IDecision 
{
    // Base for all Decisions //
    void Action(); 
}

public class RecruitDecision : IDecision
{
    UnitSO Units;//What 
    Faction Faction;//Who
    County County;//Where
    int num; //HowMany

    public RecruitDecision(Faction faction, int RecruitNumber, UnitSO Units, County county)
    {
        County = county; 
        this.Units = Units;
        Faction = faction;
        num = RecruitNumber; 
    }

    public void Action()
    {
        UnitRecruitmentObject Recruiter = County.GetComponent<UnitRecruitmentObject>();

        for (int i = 0; i < num; i++)
        {
            Recruiter.CurrentlyRecruiting1 = Units;
            Recruiter.RecruitNewUnit();
        }
    }
}

public class IncomeDecision : IDecision
{
    Faction Faction;//who
    int income;//how much

    public IncomeDecision(Faction faction, int money)
    {
        faction = Faction; income = money; 
    }

    public void Action()
    {
        Faction.Economy.Bank += income; 
    }
}

public class TerritoryDecision: IDecision
{
    Faction faction;//who
    County county;//which ones
    
    public TerritoryDecision(Faction faction, County county)
    {
        this.faction = faction; this.county = county; 
    }

    public void Action()
    {
        faction.NewTerritory(county);
    }
}