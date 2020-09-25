using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMBARD_SceneUpdate : MonoBehaviour {
    float delay = 0.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
        Debug.Log("Current time is " + Time.time + "----THe wait time is:" + nextUsage);
        delay = 0.5f; //only half delay
        nextUsage = 0;
        GameObject.Find("PlayerShip").GetComponent<playerController>().isPlayerCamping = true;
        GameObject.Find("PlayerShip").transform.position = GameObject.Find("ExitZone").transform.position;
    }

    bool dothisReappearOnce = false;
    bool introGone = false;
    private void LateUpdate()
    {
        if (GameObject.Find("PlayerShip").GetComponent<playerController>().isPlayerCamping == false && GameObject.Find("transportShip").gameObject.transform.localScale.x >= 0 && introGone == false)
        {
            //player has left the ship, shrink it!
            GameObject.Find("transportShip").gameObject.transform.localScale -= new Vector3(0.0025f, 0.0025f, 0);
            if (GameObject.Find("transportShip").gameObject.transform.localScale.x <= 0)
            {
                introGone = true;
            }
        }
    }
    // Update is called once per frame
    void Update () {
 

        if (GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave == true && dothisReappearOnce == false)
        {
    //        Debug.Log("PACKAGE GOT SHIP REAPPEAR!" + GameObject.Find("transportShip").gameObject.transform.localScale.x);
            GameObject.Find("transportShip").gameObject.transform.localScale += new Vector3(0.0025f, 0.0025f, 0);
            if (GameObject.Find("transportShip").gameObject.transform.localScale.x >= 0.35f)
            {
                dothisReappearOnce = true;
            }


        }
        // Debug.Log("Current time is " + Time.time + "----THe wait time is:" + nextUsage);
     if   (GameObject.Find("PlayerShip").GetComponent<playerController>().isPlayerCamping == false)
            {
            if (GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave == false)
            {

                if (Time.time > nextUsage)
                {
                    //      Debug.Log("HEYHEYHEY");
                    int randoSpawno = UnityEngine.Random.Range(2, 5);
                    for (int i = 0; i < randoSpawno; i++)
                    {
                        GameObject ExpDust = Instantiate(Resources.Load("FallingAst")) as GameObject;
                        ExpDust.name = "FallingAst";
                        ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-8, 8), 7.5f);
                        ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(0.5f, 2), UnityEngine.Random.Range(0.5f, 2));
                        ExpDust.GetComponent<PolygonCollider2D>().isTrigger = true;
                        // ExpDust.transform.eulerAngles = Vector3.forward * UnityEngine.Random.Range(0, 360); ;
                        ExpDust.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector3.up * 999999);
                        //   rb.AddForce(-transform.up * 2);
                    }
                    nextUsage = Time.time + delay; //it is on display
                }
            }
        }
    }
}
