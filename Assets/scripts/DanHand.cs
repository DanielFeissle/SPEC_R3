using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanHand : MonoBehaviour {
    bool handAttack = false; //one time for the stage only
    int handStage = 0;
    private Camera cam;
    Renderer m_Renderer;
    private Rigidbody2D rb;
    private Vector3 originalRotation;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        originalRotation = transform.localEulerAngles;

    }
    AudioClip _audio7;
    // Update is called once per frame
    void Update () {
		
        if (GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave==true )
        {
            if (handAttack==false)
            {
                _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\danHandScreenYou");
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            }
            if (handStage == 0)
            {
                StartCoroutine(HandMoveUp());
                handAttack = true;
            }
            else if (handStage == 1)
            {
                StartCoroutine(RotateHandRando());
            }
 
         


 
        }

	}






    IEnumerator HandMoveUp()
    {

        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

        while (this.transform.position.y<((p.y+q.y)/2)) // get the middle of the screen, wherever it may be
        {
            yield return new WaitForSeconds(0.01f);
            rb.AddForce(new Vector2(0.0f, 0.75f));
        }

        rb.velocity = Vector2.zero;
        GameObject.Find("spacedBackground(1024x1024)").GetComponent<Animator>().SetBool("ISBROKE", true);
        handStage = 1;

    }

    IEnumerator RotateHandRando()
    {

        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        int randoShakes = UnityEngine.Random.Range(2, 15);
        float randoRange = UnityEngine.Random.Range(0.05f, 0.25f);

        for (int i=0; i<randoShakes;i++)
        {
            while (this.transform.rotation.z > .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (-10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
            }
            while (this.transform.rotation.z < .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
            }
            while (this.transform.rotation.z > .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (-10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
            }
            while (this.transform.rotation.z < .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
                StartCoroutine(BackgroundGrowAndLeave());
            }
            while (this.transform.rotation.z > .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (-10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
            }
            while (this.transform.rotation.z < .14)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Rotate(0, 0, (10) * Time.deltaTime);
                Debug.Log("RotLevel: " + this.transform.rotation.z);
            }
            StartCoroutine(HandMoveAway());

        }


        rb.velocity = Vector2.zero;
        GameObject.Find("spacedBackground(1024x1024)").GetComponent<Animator>().SetBool("ISBROKE", true);
        handStage = 2;
    }

    IEnumerator BackgroundGrowAndLeave()
    {
        Destroy(GameObject.Find("stage_masterHold"));
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        int opEffect = 1;
        int quadGo = 0;
        while (GameObject.Find("spacedBackground(1024x1024)").transform.localScale.x < 6) // get the middle of the screen, wherever it may be
        {
            yield return new WaitForSeconds(1.11f);
            GameObject.Find("spacedBackground(1024x1024)").transform.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);


            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
            {
              
                    
                if (go.CompareTag("SpaceJunk"))
                {
                    quadGo++;
                    if (quadGo > 1)
                    {
                        go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7 * opEffect);
                        quadGo = 0;
                    }
                 
                }
                quadGo++;
                if (go.CompareTag("Player"))
                {
                    go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7 * opEffect);
                }


            }
            
            opEffect = opEffect * -1;


        }
        
        rb.velocity = Vector2.zero;
        GameObject.Find("spacedBackground(1024x1024)").GetComponent<Animator>().SetBool("ISBROKE", true);
        handStage = 3;
        Destroy(this.gameObject);
    }


    IEnumerator HandMoveAway()
    {
 
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        while (m_Renderer.isVisible) // get the middle of the screen, wherever it may be
        {
            yield return new WaitForSeconds(0.01f);
            rb.AddForce(new Vector2(-0.45f, -0.75f));
        }
        GameObject.Find("transportShip").transform.position = new Vector2(GameObject.Find("transportShip").transform.position.x -.001f, 0); //move the ship more towards the middle
        rb.velocity = Vector2.zero;
        GameObject.Find("spacedBackground(1024x1024)").GetComponent<Animator>().SetBool("ISBROKE", true);
        handStage = 1;
        
    }



}
