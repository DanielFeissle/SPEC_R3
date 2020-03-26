using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class ScaleFont : MonoBehaviour {
    //3-24-20- this does not need to be used at all..
    //leaving this note here
    //To change the UI scale, go to the canvas in unity
    //The notice there is already a script/component called Canvas Scaler
    //Change the scale mode!!!

        //Does not need any of these scripts below
    //updated to work in 2017 version
    // https://forum.unity.com/threads/changing-text-size-relative-to-screen.102876/
    /*
     * 1. Create a C# script called ScaleFont
 2. Paste in this code
 3. Drop the script on your GUIText
 4. Set your font size as a base and the ratio will scale from there.

     */ 

     // Use this for initialization
     public Vector2 offset;

     public float ratio = 10;

     // Use this for initialization
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }
     void OnGUI()
     {

         float finalSize = (float)Screen.width / ratio;
        //   this.GetComponent<GUIText>().fontSize = (int)finalSize;
      //  this.GetComponent<GUIText>().fontSize = (int)finalSize;
         // guiText.fontSize = (int)finalSize;
      //   this.GetComponent<GUIText>().pixelOffset= new Vector2(offset.x * Screen.width, offset.y * Screen.height);
      //   guiText.pixelOffset = new Vector2(offset.x * Screen.width, offset.y * Screen.height);
     }
 }
