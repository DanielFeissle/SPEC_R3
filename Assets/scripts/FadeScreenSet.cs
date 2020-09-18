using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScreenSet : MonoBehaviour {
    public GameObject FadeScreen;
    public void FadeingOut()
    {
        FadeScreen.GetComponent<Animation>().Play("FadeAni");
    }
	// Use this for initialization
	void Start () {
		
	}
	

}
