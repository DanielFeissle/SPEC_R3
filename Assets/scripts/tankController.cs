using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankController : MonoBehaviour
{
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    bool controlerUsed = false;
    private Rigidbody2D rb;
    public float speed;
    Renderer m_Renderer;
    float nextUsage;
    float delay = 0.15f; //only half delay
    public float moveVertical;
    public float moveHorizantal;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        nextUsage = Time.time + delay; //it is on display
    }

    // Update is called once per frame
    void Update()
    {







        //this will help limit the speed gaps gained by the new attempt at detecting if an object is inside another (9-14-19)
        if (rb.velocity.magnitude > 8) //max speed is this
        {
            rb.velocity = rb.velocity.normalized * 8;
        }



        //https://answers.unity.com/questions/131899/how-do-i-check-what-input-device-is-currently-beei.html

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //   print(names[x].Length);
            //  print(names[x]);
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















        //Player Rotation section
        //--------------------------------------------------------

        moveVertical = 0;
        // Debug.Log("Controller" + controlerUsed);
        if (controlerUsed == false)
        {
            moveVertical = Input.GetAxis("Vertical");
        }

        moveHorizantal = Input.GetAxis("Horizontal");

        //if (Input.GetButtonDown("360_RightBumper"))
        float TriggerRight = Input.GetAxis("Cont_Trigger");
        //   Debug.Log("Your Value for Trigger is " + TriggerRight);
        if (TriggerRight != 0) //controller support
        {
            moveVertical = TriggerRight * -1;
        }

        moveHorizantal = moveHorizantal * 2;
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
            //  rotation = rotation + Time.deltaTime;
        }
        //  transform.Rotate(new Vector3(0.0f, 0.0f, rotation));
        //--------------------------------------------------------






        //PlayerMove control handler
        //====================================================================



            if (moveVertical > 0) //moving up so go foward
            {

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
                //           Debug.Log("------------------" + totspeed);
                //            Debug.Log("==================" + rb.velocity.sqrMagnitude);

                if (rb.velocity.x < 32)
                {//increase speed, ie faster getup 10-13-19
                    rb.AddRelativeForce(Vector3.up * 225 * Time.deltaTime * speed);

               //     AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
               //     AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
              //      AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));

                }
                else
                {
                    rb.AddRelativeForce(Vector3.up * 55 * Time.deltaTime * speed);


                }

        


                var renderer2 = this.GetComponent<Renderer>();
                float heighth = renderer2.bounds.size.y;
       
                rb.drag = 0;
            }
            else if (moveVertical < 0)
            {
                float totspeed = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));

                rb.drag = 1;
            
              

            }
            else
            {
                //no keypress
                rb.drag = 0;
            
           
            }


            //====================================================================


    }



        private void LateUpdate()
    {
        //handle player shots in a different location (try to be clean about this!) 9-29-20
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > nextUsage) //delete otherwise
            {

                int randSFX = UnityEngine.Random.Range(1, 6);
                Debug.Log("Your random sfx" + randSFX);
                if (randSFX == 1)
                {
                //    AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                 //   AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                }
                else if (randSFX == 2)
                {
                //    AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                }
                else if (randSFX == 3)
                {
                 //   AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                 //   AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                }
                else if (randSFX == 4)
                {
                //    AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                 //   AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                }
                else if (randSFX == 5)
                {
                //    AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                //    AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                }

                nextUsage = Time.time + delay; //it is on display
            }


        }
    }
}
