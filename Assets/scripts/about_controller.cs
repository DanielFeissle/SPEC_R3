using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class about_controller : MonoBehaviour {


    public Scrollbar scrollbar; // assign in the inspector
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Use this for initialization
    void Start () {
        if (scrollbar != null)
        { 
            scrollbar.onValueChanged.AddListener(onScroll);
            EventSystem.current.firstSelectedGameObject = GameObject.Find("Scrollbar");
        }

       int gameFinished = PlayerPrefs.GetInt("GameFinished");
        if (gameFinished==111) //10-12-20 just putting this in
        {
            GameObject.Find("Hallway1(512x512)").GetComponent<SpriteRenderer>().sortingOrder = -22;
        }
    }
    private void onScroll(float value)
    {
        //retrieved 9-23-20
        //https://forum.unity.com/threads/let-the-camera-move-with-a-scrollbar.486359/
        transform.position = Vector3.Lerp(minPosition, maxPosition, value);
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire2"))
        {
           // GameObject.Find("Hallway1(512x512)").GetComponent<SpriteRenderer>().sortingOrder = -22;
        }

		if (Input.GetButton("Fire3"))
            {
            Debug.Log("QUIT");
            Destroy(GameObject.Find("PlayerShip"));
            SceneManager.LoadScene("title");
        }
	}
}
