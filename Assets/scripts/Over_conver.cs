using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over_conver : MonoBehaviour {

    int totalDialog = 0;
    string[] super = new string[9999];
    string[] LineItem = new string[2];
    int charCount = 0;
    int superCount = 0;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public string PullValue(int charTalk)
    {
        charCount = 0;
        superCount = 0;
        TextAsset txt = (TextAsset)Resources.Load("meta\\dia", typeof(TextAsset));
        string content = txt.text;
        try
        {
            super = txt.text.Split('\n'); //C#
        }
        catch (Exception ex) //quit out fast
        {
            Debug.Log(ex);
            Application.Quit();
        }
        Debug.Log("Array Intialized Complete");
        for (int i=0;i<super.Length;i++)
        {
            LineItem = super[i].Split(','); //only do this on scene load, the rest will be handled in the main update loop
            if (LineItem[0] == charTalk.ToString())
            {
                charCount++;
            }
               
        }

        string[] SpecSuper=new string[charCount];
        for (int i = 0; i < super.Length; i++)
        {
            LineItem = super[i].Split(','); //only do this on scene load, the rest will be handled in the main update loop
            if (LineItem[0] == charTalk.ToString())
            {
                //we will add this to the random range
                SpecSuper[superCount] = LineItem[1];
                superCount++;
            }

        }

        //   totalDialog = super[0].Split(',').Length;
        Debug.Log("total dialog" + (super.Length - 1));
        Debug.Log("char related dialog" + (SpecSuper.Length - 1)+ " Char Val:"+charTalk);
        int randoVal = UnityEngine.Random.Range(0, SpecSuper.Length);
        return SpecSuper[randoVal];
       
    }
        
}
