/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public class PopulationBreakdown : MonoBehaviour
{
    CountySO county;

    public CountySO County { get => county; set => county = value; }

    [SerializeField]
    GameObject CityPopulationBreakdownPrefab = null;

    private void Awake()
    {
        foreach(Faction f in GameManager.Instance.All_Factions)
        {
            if (f.isPlayer)
            {
                county = f.territory[0].County_Object;
            }
        }
        foreach(City c in county.Settlements1)
        {
            CityInformationDisplay display = Instantiate(CityPopulationBreakdownPrefab, transform).GetComponent<CityInformationDisplay>();
            display.Name.text = c.Name; 
            foreach(Pop pop in c.Pops)
            {
                display.Size.text = pop.population + "";
                display.Ethnicity.text = pop.ethnicity + "";
                display.Happiness.text = pop.happiness + "";
                display.Job.text = pop.Job + "";
                display.Ferver.text = pop.ferver + "";
                display.Desire.text = pop.Desire + "";
            }
        }
    }

    public void UpdateBreakdown(County County)
    {
        foreach (City c in County.County_Object.Settlements1)
        {
            Debug.Log(c.Name);
            foreach (Pop pop in c.Pops)
            {
                Debug.Log(pop.population);
                Debug.Log(pop.ethnicity);
                Debug.Log(pop.happiness);
                Debug.Log(pop.Job);
                Debug.Log(pop.ferver);
                Debug.Log(pop.Desire);
            }
        }
    }
}
