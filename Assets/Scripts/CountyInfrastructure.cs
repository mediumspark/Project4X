/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;


//Unused
//County Infrastructure can be used to impact County Infrustructure
public class CountyInfrastructure : MonoBehaviour
{
    bool contains_airfield, contains_recruitment_camp, contains_helo_base, contains_forward_base;
    [SerializeField]
    int AFlv, RClv, HBlv, FBlv; 
    int infrustructure_Level; 
    public bool Contains_airfield { get => contains_airfield; set => contains_airfield = value; }
    public bool Contains_recruitment_camp { get => contains_recruitment_camp; set => contains_recruitment_camp = value; }
    public bool Contains_helo_base { get => contains_helo_base; set => contains_helo_base = value; }
    public bool Contains_forward_base { get => contains_forward_base; set => contains_forward_base = value; }
    public int Infrustructure_Level { get => infrustructure_Level; set => infrustructure_Level = value; }

    airfield AF;
    recruitmentcamp RC;
    helobase HB;
    forward_base FB;

    struct airfield
    {
        int level { get; set; }
    }

    struct recruitmentcamp
    {
        int level { get; set; }
    }

    struct helobase
    {
        int level { get; set; }
    }

    struct forward_base
    {
        int level { get; set; }
    }

}


