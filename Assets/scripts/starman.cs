using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starman : MonoBehaviour {
    //7-22-20
    //the purpose of this script is for a star to appear and distract the player while the pieces are set on the screen again
    private GameObject sphere;
    private Vector3 scaleChange;

    public float max = 1f;
    public float speed = 0.0005f;

    public SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        sphere = this.gameObject;
        scaleChange = new Vector3(+0.71f, +0.71f, +0.71f);

    }
	
	// Update is called once per frame
	void Update () {
        sphere.transform.localScale += scaleChange;
        sprite.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * speed, max));
       // Debug.Log("Color is " + sprite.color);
      
        if (sphere.transform.localScale.x>77 && sprite.color.a<0.15f)
        {
            Destroy(this.gameObject);
        }
    }
}
