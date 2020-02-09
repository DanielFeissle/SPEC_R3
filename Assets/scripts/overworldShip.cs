using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overworldShip : MonoBehaviour {
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
    float nextUsage2 = -10;
    float delay = 0.15f; //only half delay
    float nextUsage22;
    float delay2 = 0.10f; //only half delay
    float nextUsage222;
    float delay22 = 0.10f; //only half delay
    float nextUsage2222;
    float delay222 = 2; //only half delay
 public   bool lineOut = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        lineOut = false;

    //    ani = GameObject.Find("string").GetComponent<Animator>();
    }

    public Animator ani;

    IEnumerator MovePlayerToCentral()
    {
       // coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.x < 25)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
       // coRun = false;
    }


    private void LateUpdate()
    {

        if (Input.GetButton("Fire1") && rb.velocity.magnitude<=2)
        {
            if (lineOut==false) //shoot the line out
            {
                if (GameObject.Find("string")) //only one fishing line at a time
                {
                  
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll; //while fishing you dont move, doi 1-30-20
                    rb.freezeRotation = true;
                    GameObject VBurp = Instantiate(Resources.Load("GalLine")) as GameObject;
                    VBurp.name = "string2";
                    GameObject.Find("GalLine2").name = "string";
                    VBurp.transform.position = GameObject.Find("headShip(256x256_SINGLE)").transform.position + new Vector3(m_Renderer.bounds.size.x / 2, VBurp.GetComponent<Renderer>().bounds.size.y);
                    VBurp.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.transform.eulerAngles.z-90));
              //      VBurp.transform.localEulerAngles = new Vector3(0.0f, 0.0f, this.transform.localEulerAngles.z);
                    lineOut = true;
                    ani = GameObject.Find("string").GetComponent<Animator>();

                   
                }
               
            }
            else
            {
                if (ani.GetCurrentAnimatorStateInfo(0).IsName("string") &&
ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {

                    if (lineOut == true)
                    {
                        //   GameObject.Find("transportShip").GetComponent<overworldShip>().lineOut = false;

                        ani.SetBool("ISRETRACT", true); //retract the line
                    }
                    //   Destroy(this.gameObject);
                }
            
            }
        }
       

        if ( GameObject.Find("string")) //only one fishing line at a time
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Retract") &&
ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.freezeRotation = false; //we don't use the rigid body to rotate, we do this manually 
             //   rb.drag = 0;
                ani.SetBool("ISRETRACT", false); //retract the line
                lineOut = false;
                Destroy(GameObject.Find("string"));
            }
        }

       

    }
    // Update is called once per frame
    void Update () {
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
          //  print(names[x].Length);
         //   print(names[x]);
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






    public Text StageSector;

    private void FixedUpdate()
    {
        //12-12-19: get the pos and display it
        //     GameObject.Find("txt_POS").GetComponent<TextMesh>().text = "FU";
        GameObject dad5 = GameObject.Find("txt_POS");
        StageSector = dad5.GetComponent<Text>();


        StageSector.text = "Sector: ("+(Mathf.RoundToInt(this.transform.position.x)/10) + "," + (Mathf.RoundToInt(this.transform.position.y) / 10)+ ")";



 
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
        if (lineOut==false)
        {
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
            //  transform.Rotate(new Vector3(0.0f, 0.0f, rotation));
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

            if (rb.velocity.sqrMagnitude < 12 && engineCnt > 0 && lineOut==false)
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
