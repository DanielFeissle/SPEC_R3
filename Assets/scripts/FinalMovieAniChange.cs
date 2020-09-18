using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMovieAniChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   public AudioClip _audio6;
    bool onlyDothisOnce = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HotAst") &&onlyDothisOnce==false)
        {
            onlyDothisOnce = true;
            this.gameObject.GetComponent<Animator>().SetBool("ISMOVIEDEAD", true);
            AudioSource.PlayClipAtPoint(_audio6, GameObject.Find("Main Audio").transform.position, 77);
            //   ISMOVIEDEAD
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
