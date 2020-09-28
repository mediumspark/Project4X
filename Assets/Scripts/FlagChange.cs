/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections;
using UnityEngine;

public class FlagChange : MonoBehaviour
{
    Material M;
    [SerializeField]
    string[] Flags;
    int FlatIterator = 0; 

    private void Awake()
    {
        M = GetComponent<MeshRenderer>().material;
    }

    IEnumerator Start()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSecondsRealtime(5);
            GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Material>("Textures/" + Flags[FlatIterator]).mainTexture;
            FlatIterator++;

            if (FlatIterator == 5)
            {
                FlatIterator = 0;
            }
        }
    }
}
