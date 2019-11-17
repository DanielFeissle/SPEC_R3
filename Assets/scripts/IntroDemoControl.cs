using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDemoControl : MonoBehaviour {
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    bool controlerUsed = false;
    Renderer m_Renderer;
    public float speed;
    private Rigidbody2D rb;
    public AudioClip shipShift;
    public int shipHitDetect = 0; //0-nothing 1-something (no duh)---its actually boost, 2-turd is off screen
    bool readyBoost = true;
    public int moveCount = 0;
    int engineCnt = 0;

    float nextUsage;
    float nextUsage2;
    float delay = 1f; //only half delay
    float nextUsage22;
    float delay2 = 3.10f; //only half delay
    float nextUsage222;
    float delay22 = 0.10f; //only half delay
    float nextUsage2222;
    float delay222 = 2; //only half delay


    float nextUsage4;
    float delay4 = 0.15f; //only half delay

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        nextUsage4 = Time.time + delay4; //it is on display\
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {


        if (Time.time > nextUsage4) //delete otherwise
        {
            GameObject PoopPEE = Instantiate(Resources.Load("poo")) as GameObject;
            PoopPEE.name = "iPoo";
            //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
            PoopPEE.transform.position = transform.position - (transform.up / 1.35f);
            PoopPEE.transform.localScale = transform.localScale * 4;

            nextUsage4 = Time.time + delay4; //it is on display
        }


        if (Time.time > nextUsage2222 && readyBoost == false) //delete otherwise
        {

            readyBoost = true;
            nextUsage2222 = Time.time + delay222; //it is on display
        }


        //this will help limit the speed gaps gained by the new attempt at detecting if an object is inside another (9-14-19)
        if (rb.velocity.magnitude > 8) //max speed is this
        {
            rb.velocity = rb.velocity.normalized * 8;
        }



        //https://answers.unity.com/questions/131899/how-do-i-check-what-input-device-is-currently-beei.html

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            print(names[x]);
            if (names[x].Length == 0)
            {
                //disconnected, switch back to mouse/keyboard
                controlerUsed = false;
                PS4_Controller = 0;
                Xbox_One_Controller = 0;
            }
            if (names[x].Contains("PS"))
            {
                //  print("PS* CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Contains("Xbox"))
            {
                //  print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }

        if (names.Length == 0)
        {
            //disconnected, switch back to mouse/keyboard
            controlerUsed = false;
            PS4_Controller = 0;
            Xbox_One_Controller = 0;
        }
        if (Xbox_One_Controller == 1)
        {
            //do something
            controlerUsed = true;
        }
        else if (PS4_Controller == 1)
        {
            //do something
            controlerUsed = true;
        }
        else
        {
            // assumption of mouse and keyboard
            controlerUsed = false;
        }
    }


    float moveVertical = 0;
    float moveHorizantal = 0;

    private void FixedUpdate()
    {

        if (Time.time > nextUsage2) //continue scrolling
        {
            int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
            Debug.Log("Objects on asteroid screen: " + objectCount);

            if (objectCount < 555)
            {
                int fundas = UnityEngine.Random.Range(0, 100);
                if (fundas < 25)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                    ExpDust.name = "AstMan2019";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-3,3), UnityEngine.Random.Range(-1.5f,1.5f));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                    //ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }
                else if (fundas < 50)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                    ExpDust.name = "Asteroid2017";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-3,3), UnityEngine.Random.Range(-1.5f,1.5f));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                //    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

                }
                else if (fundas < 75)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                    ExpDust.name = "blueWallJunk";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-3,3), UnityEngine.Random.Range(-1.5f,1.5f));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
                //    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }
                else if (fundas < 100)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                    ExpDust.name = "StdWall";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-3,3), UnityEngine.Random.Range(-1.5f,1.5f));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
                 //   ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }

                //   GameObject AsteroidBelt = Instantiate(Resources.Load("atmp\\cloud2017")) as GameObject;
                //    AsteroidBelt.name = "Asteroid2019";

            }
            nextUsage2 = Time.time + delay2; //it is on display
        }



        /*
        float moveVertical = 0;
        // Debug.Log("Controller" + controlerUsed);
        if (controlerUsed == false)
        {
            moveVertical = Input.GetAxis("Vertical");
        }

        float moveHorizantal = Input.GetAxis("Horizontal");

        //if (Input.GetButtonDown("360_RightBumper"))
        float TriggerRight = Input.GetAxis("Cont_Trigger");
        //   Debug.Log("Your Value for Trigger is " + TriggerRight);
        if (TriggerRight != 0) //controller support
        {
            moveVertical = TriggerRight * -1;
        }

        moveHorizantal = moveHorizantal * 2;

        //  transform.Rotate(new Vector3(0.0f, 0.0f, rotation));

    */

        //random controler range 11-17-19
        float rand1 = UnityEngine.Random.Range(0, 100);
        float rand2 = UnityEngine.Random.Range(0, 100);
        if (Time.time > nextUsage) //delete otherwise
        {
          
            if (rand1<36)
            {
                moveVertical = 0;
            }
            else if (rand1 < 66)
            {
                moveVertical = 1;
            }
            else
            {
                moveVertical = -1;
            }

            if (rand2 < 36)
            {
                moveHorizantal = 0;
            }
            else if (rand2 < 66)
            {
                moveHorizantal = 1;
            }
            else
            {
                moveHorizantal = -1;
            }
           
            nextUsage = Time.time + delay; //it is on display
        }

        if (moveHorizantal > 0)
        {
            transform.Rotate(0, 0, -188 * Time.deltaTime);
            //rb.velocity = Vector3.zero;

        }
        else if (moveHorizantal < 0)
        {
            transform.Rotate(0, 0, 188 * Time.deltaTime);
            // rb.velocity = Vector3.zero;
        }
        float rotation = transform.rotation.z;
        if (rotation >= 0)
        {
            rotation = rotation + Time.deltaTime;
        }
        if (moveVertical > 0) //moving up so go foward
        {
            moveCount++;
            //   Vector3 movement = transform.position += transform.up * Time.deltaTime * 5;
            //  rb.transform.position += transform.up * Time.deltaTime * 5;
            /////  rb.AddForce(transform.position += transform.up * Time.deltaTime * speed);
            ///
            float totspeed = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
            if (rb.velocity.magnitude > 8) //max speed is this
            {
                rb.velocity = rb.velocity.normalized * 8;
            }
            // Debug.Log(totspeed);
            Debug.Log("------------------" + totspeed);
            Debug.Log("==================" + rb.velocity.sqrMagnitude);

            if (rb.velocity.sqrMagnitude < 12 && engineCnt > 0)
            {//increase speed, ie faster getup 10-13-19
                rb.AddRelativeForce(Vector3.up * 225 * Time.deltaTime * speed);

                AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                engineCnt = 0;
            }
            else
            {
                rb.AddRelativeForce(Vector3.up * 55 * Time.deltaTime * speed);
                if (Time.time > nextUsage222) //delete otherwise
                {
                    engineCnt = engineCnt + 1;
                    nextUsage222 = Time.time + delay22; //it is on display
                }

            }

            // rb.AddRelativeForce(Vector3.right * 6);
            ///


            //   Debug.Log("Write "+transform.position);




            var renderer2 = this.GetComponent<Renderer>();
            float heighth = renderer2.bounds.size.y;
            //   ExpDust.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            //////////       ff.transform.position = new Vector3(this.transform.position.x,heighth,0.0f);
            // ff.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.transform.rotation.z));
            ///////////    ff.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, ((this.transform.rotation.z)*100) - 90.0f));
            //rb.AddForce((movement * speed) * 2);
            //     ff.transform.position = blastLoc;
            //  transform.position += Vector3.forward * Time.deltaTime * movementSpeed;


            rb.drag = 0;
        }
        else if (moveVertical < 0)
        {
            float totspeed = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
            // rb.velocity = Vector3.ClampMagnitude(rb.velocity,1);

            // rb.AddForce(-transform.up * 2);
            rb.drag = 1;
            moveCount = 0;
            //  Debug.Log(totspeed);

        }
        else
        {
            //no keypress
            rb.drag = 0;



            moveCount = 0;
            //  ff.transform.position = new Vector2(100,100);
        }

        //     rb.AddForce((this.transform.TransformVector(Vector3.forward) * speed) *2);
        //   Debug.Log(rb.velocity);
        //FINAL CHECK:
        //check if the player is completly gone, if so return to the screen
        if (m_Renderer.isVisible)
        {
            //  //debug.log("object is visible");
        }
        else
        {

            //stage introductions
            shipHitDetect = 2;
            GameObject Cam = GameObject.Find("Main Camera");
            Transform ff = Cam.GetComponent<Transform>();
            transform.position = new Vector2(ff.position.x, ff.position.y);
            //  Debug.Log("Object is no longer visible");

        }

    }
}
