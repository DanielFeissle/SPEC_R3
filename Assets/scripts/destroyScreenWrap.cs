using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyScreenWrap : MonoBehaviour {
   public int screenWrapCount = 0;
    bool checkAgain = false;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        screenWrapCount = 0;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (checkAgain==false)
        {
            if (GetComponent<Renderer>().isVisible)
            //  {
            //   if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");
            }
            else
            {
                checkAgain = true;
                StartCoroutine(waitABit()); //move to ship
                screenWrapCount++;
                if (screenWrapCount > 3)
                {
                    Destroy(this.gameObject);
                }
                // Debug.Log("Object is no longer visible");
                //  Debug.Log("X:" + fartX + "Y:" + fartY);

            }
        }
      
    }
    IEnumerator waitABit()
    {
        int waiter = 0;
    
        while (waiter < 5)
        {
            yield return new WaitForSeconds(0.25f);
            waiter++;

        }
        checkAgain = false;//reset the checker
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     
    }
}
