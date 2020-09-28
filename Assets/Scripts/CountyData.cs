/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//Holds the list of all counties in the game so they can be referenced from a single place
public class CountyData : MonoBehaviour
{
    public County Origin; 

    [SerializeField]
    List<County> counties = new List<County>();

    public List<County> Counties { get => counties; }
    
    public static CountyData Instance { get => FindObjectOfType<CountyData>(); }

    private void Awake()
    {
        counties = FindObjectsOfType<County>().ToList();        
    }
}
