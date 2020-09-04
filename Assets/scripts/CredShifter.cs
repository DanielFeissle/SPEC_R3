using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CredShifter : MonoBehaviour {
    float nextUsage;
    float delay = 0.251f; //only half delay
    FileInfo[] info;
   int cnt=0;
    Renderer m_Renderer;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        //7-7-20
        //this is a prototype/idea for the credits
        //if sucessful can be used in other games for switching sprites

        Debug.Log("This is: start ");
        DirectoryInfo dir = new DirectoryInfo("Assets/resources");
        info = dir.GetFiles("*.prefab");
        foreach (FileInfo f in info)
        {
            
            string[] SpecFinale = f.ToString().Split('\\');
            string SpecVal = SpecFinale[SpecFinale.Length-1];
            SpecVal = SpecVal.Split('.')[0];
         //   Debug.Log("This is: " + SpecVal);
            //  Sprite fun=  LoadNewSprite("sprites\\" + SpecVal + ".png");
       
            /*   try
               {
                   progresssToNext = false;
                        GameObject ExpDust = Instantiate(Resources.Load(SpecVal),SpriteRenderer) as GameObject;
                   Destroy(ExpDust.GetComponent<MonoScript>());
                   ExpDust.name = SpecVal;
                   ExpDust.transform.position = this.transform.position;
                   ExpDust.transform.localScale = new Vector2(.5f, .5f);
                   StartCoroutine(DelayLoop(SpecVal));

                   Destroy(ExpDust);
               }
               catch
               {
                   Debug.Log("NOPE");
               }

    */






    }

    nextUsage = Time.time + delay; //it is on display
         
    }

    //https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

        Sprite NewSprite = new Sprite();
        Texture2D SpriteTexture = LoadTexture(FilePath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

        return NewSprite;
    }

    private static CredShifter _instance;

    public static CredShifter instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.

            if (_instance == null)
                _instance = GameObject.FindObjectOfType<CredShifter>();
            return _instance;
        }
    }

    IEnumerator DelayLoop(string SpecVal)
    {
       

        yield return new WaitForSeconds(1.01f);
 

    }

        // Update is called once per frame
        void Update () {
        if (Time.time > nextUsage) //delete otherwise
        {
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");
          
            if (cnt<info.Length)
            {
                Debug.Log("sprite value" + gameObject.GetComponent<SpriteRenderer>().sprite.name);
                string[] SpecFinale = info[cnt].ToString().Split('\\');
                string SpecVal = SpecFinale[SpecFinale.Length - 1];
                SpecVal = SpecVal.Split('.')[0];
                Debug.Log("Loop mode: " + SpecVal);
                // Sprite fun = LoadNewSprite(info[cnt].ToString());
                //        Sprite pauseSprite = Resources.Load<Sprite>(SpecVal);
                //     Sprite pauseSprite = Resources.Load<Sprite>("Asteroid2019");
                //         GameObject ExpDust = Instantiate(Resources.Load(SpecVal),SpriteRenderer) as GameObject;
                GameObject pauseSprite = (Resources.Load(SpecVal)) as GameObject;
                try
                {
                    if (pauseSprite.GetComponent<SpriteRenderer>())
                    {
                        //it has the component, go and show it!
                        Sprite coolCred = pauseSprite.GetComponent<SpriteRenderer>().sprite;
                        //  string pauseSprite = Resources.Load<Sprite>("Asteroid2019").name;

                        //      Debug.Log("THIS IS SOMETHING " + coolCred.name.ToString() + " HAHAHAH");
                        GameObject.Find("txt_spriteTitl").GetComponent<TextMesh>().text = coolCred.name.ToString();
                        gameObject.GetComponent<SpriteRenderer>().sprite = coolCred;
                        nextUsage = Time.time + delay; //it is on display 
                    }
                    else
                    {
                        //does not have a valid sprite, do not show it
                        nextUsage = Time.time + delay; //it is on display 
                    }
                }
                catch
                {
                    Debug.Log("Sprite issue that could not be caught alert");
                    nextUsage = Time.time + delay; //it is on display 
                }
             

                

                cnt++;
                if (cnt>info.Length-1)
                {
                    GameObject.Find("txt_spriteTitl").GetComponent<TextMesh>().text = "";
                    this.transform.position = new Vector2(500, -500);
                }
            }
            }
        }
    }
}
