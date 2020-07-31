using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerFightTracker : MonoBehaviour {
    public string[,] bossTracker = new string[99, 2];
    FileInfo[] info;
    int cnt;
    // Use this for initialization
    void Start () {
        //7-27-20
        //any thing in the boss folder will be counted as a boss
        //the org purpose of this is to prevent the player if dead from a boss 
        //to get a new boss- with this the player should keep getting the same boss.
        //it does not (yet) narrow down bosses (and probably in spec r3 will not because of how the planning went!)
        cnt = 0;
        Debug.Log("This is: start ");
        DirectoryInfo dir = new DirectoryInfo("Assets/resources/boss");
        info = dir.GetFiles("*.prefab");
        foreach (FileInfo f in info)
        {

            string[] SpecFinale = f.ToString().Split('\\');
            string SpecVal = SpecFinale[SpecFinale.Length - 1];
            SpecVal = SpecVal.Split('.')[0];
            Debug.Log("This is: " + SpecVal);
            bossTracker[cnt, 0] = SpecVal;
            bossTracker[cnt, 1] = "ALIVE";

            cnt =cnt+1;
        }
    }

 

    // Update is called once per frame
    void Update () {
		
	}
}
