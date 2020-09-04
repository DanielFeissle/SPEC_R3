using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneStory : MonoBehaviour {
    int closeoutCount = 0;
    float nextUsage;
    float delay = 0.501f; //only half delay
    int delayCount = 0;
    // Use this for initialization
    void Start () {
        StartCoroutine(MoveCamIn());
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextUsage && closeoutCount == 1) //delete otherwise
        {
            delayCount++;

            nextUsage = Time.time + delay; //it is on display
        }

        if (delayCount>4 && closeoutCount==1)
        {
            closeoutCount = 2;
        }
    }








    IEnumerator MoveCamIn()
    {
      
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (CameFind.GetComponent<Camera>().orthographicSize >= 7.75f)
        {
            yield return new WaitForSeconds(0.11f);
            Camera.main.orthographicSize -= 0.55f;
            Camera.main.transform.position -= new Vector3(0, .57f, 0);
            Camera.main.transform.position += new Vector3(.47f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        closeoutCount = 1;  //GOTO indy stare for a bit
    }











}
