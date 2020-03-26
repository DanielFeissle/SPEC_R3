using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject mainChar;
	// Update is called once per frame
	void Update () {
        //3-25-20
        //wait till the distance is far enough away then remove the gameobject
        float distance = Vector3.Distance(this.transform.position, GameObject.Find(mainChar.name).transform.position);

        if (distance>500)
        {
            Destroy(this.gameObject);
        }
    }
}
