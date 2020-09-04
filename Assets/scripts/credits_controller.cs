using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class credits_controller : MonoBehaviour {
    public float speed = 4;
    Renderer m_Renderer;
    Renderer m_RendererEXIT;
    bool doThisOnce = false;
    bool musicDisplay = false;
    public bool explodeHere = false;
    public AudioClip exp1;
    // Use this for initialization
    void Start () {


          
        try
        {
            //try and destroy the playership here, but first put the score's to record
            GameObject playership = GameObject.Find("PlayerShip");
            PlayerPrefs.SetInt("LocalScore", playership.GetComponent<MasterController>().gameHighScore);
            PlayerPrefs.SetInt("MasterScore", playership.GetComponent<MasterController>().masterHighScore);
            if (playership.GetComponent<playerController>().difSettings == 0)
            {
                //Normal
                PlayerPrefs.SetInt("GameFinished", 111);
            }
            else if (playership.GetComponent<playerController>().difSettings == 1)
            {
                //Easy
                PlayerPrefs.SetInt("GameFinished", 11);
            }
            else
            {
                //Mythic
                PlayerPrefs.SetInt("GameFinished", 2);
            }
            Destroy(GameObject.Find("PlayerShip"));
        }
        catch
        {
            Debug.Log("PlayerShip not found");
        }

        m_Renderer = GameObject.Find("PrefabSwitcher").GetComponent<Renderer>();
        m_RendererEXIT = GameObject.Find("indyStopper").GetComponent<Renderer>();
    }
    int skipCred = 0;
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x<55)
        {
            explodeHere = true;
        }
        else if ((this.transform.position.x > 278 &&this.transform.position.x<294 ))
        {
            explodeHere = true;
            if (this.transform.position.x < 284)
            {
                exp1 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\explosion58");
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));

            }
         

}
        else
        {
            explodeHere = false;
        }
       
if (Input.GetButton("Fire3"))
            {
            skipCred++;
        }
else
        {
            skipCred = 0; //reset the credSkip Button
        }
if (skipCred>50)
        {
            SceneManager.LoadScene("STORY_FINAL");
        }
        if (m_Renderer.isVisible )
        {
            doThisOnce = true;
            this.transform.position = new Vector3(m_Renderer.transform.position.x, this.transform.position.y, -10);
            GameObject.Find("PlayerShip2").transform.position = new Vector2(0, 0);
        }
            else if (doThisOnce == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (!m_Renderer.isVisible && doThisOnce==true &&musicDisplay==false)
        {
            musicDisplay = true;
        }
        if (musicDisplay==true)
        {
            transform.Translate(Vector3.up * -(speed/2) * Time.deltaTime);
        }
        if (m_RendererEXIT.isVisible)
        {
            SceneManager.LoadScene("STORY_FINAL");
        }
    }
}
