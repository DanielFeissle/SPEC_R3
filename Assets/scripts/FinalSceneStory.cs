using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneStory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 
	}








    IEnumerator MoverCameraNorth()
    {
      
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.y < 5.25f)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
      
    }











}
