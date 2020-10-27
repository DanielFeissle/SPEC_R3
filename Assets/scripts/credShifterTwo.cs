using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class credShifterTwo : MonoBehaviour {
    //10-26-20
    //this one is improved over the july 2020 version in that it works in the final version (not editor)
    //the only downside to this  is it takes a little bit longer to load the credits scene
    float nextUsage;
    float delay = 0.251f; //only half delay
    int cnt = 0;
    Renderer m_Renderer;
    GameObject[] objMatToCompTo;
    //  public List<GameObject> myList;
    public GameObject[] myList;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();


        //  var textures = Resources.LoadAll("Textures", typeof(Texture2D)).Cast<Texture2D>().ToArray();
        //  foreach (var t in textures)
        //      Debug.Log("HELLO THERE This is why"+t.name);
        objMatToCompTo = null;
        objMatToCompTo = Resources.LoadAll("coil", typeof(GameObject))
        .Cast<GameObject>()
        .ToArray();

      //  myList = Resources.LoadAll<GameObject>("").ToList();
        myList = Resources.LoadAll<GameObject>("");
        Debug.Log("HI MA LIST " +myList.Count());
        Debug.Log("HI MA " + objMatToCompTo[0].name.ToString());
        nextUsage = Time.time + delay; //it is on display 
    }

    // Update is called once per frame
    void Update () {



        if (Time.time > nextUsage) //delete otherwise
        {
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");

                if (cnt < myList.Length/4)
                {
                    
                    Debug.Log("sprite value" + gameObject.GetComponent<SpriteRenderer>().sprite.name);

                    Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAsprite value" + myList[cnt].GetComponent<SpriteRenderer>().name);
                    GameObject.Find("txt_spriteTitl").GetComponent<TextMesh>().text = myList[cnt].name;
                    this.GetComponent<SpriteRenderer>().sprite = myList[cnt].GetComponent<SpriteRenderer>().sprite;
                   



                    cnt++;
                  if (cnt >= myList.Length / 4)
                    {
                        GameObject.Find("txt_spriteTitl").GetComponent<TextMesh>().text = "";
                        this.transform.position = new Vector2(500, -500);
                    }
                }
            }
            nextUsage = Time.time + delay; //it is on display 
        }





    }
}
