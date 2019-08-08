using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyUSSPotatoe : MonoBehaviour
{
    public Animator ani;
    bool shotPerScreenbump = false;
   public int hp;
    private Rigidbody2D rb;

    float nextUsage;
    float delay = 0.5f; //its healing time!
                         //  public Texture2D swappedTexture = null;
                         //  private SpriteRenderer thisRenderer;

    //  public Animation ani1; // Drag your first sprite here
    // public Animation ani2; // Drag your second sprite here

    // public Sprite sprite1; // Drag your first sprite here
    //  public Sprite sprite2; // Drag your second sprite here
    //  private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        nextUsage = Time.time + delay; //it is on display
        hp = 100;
        //    spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        //   if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        //      spriteRenderer.sprite = sprite1; // set the sprite to sprite1

        //  ani = GetComponent<Animator>();

        // ani.GetCurrentAnimatorClipInfo(0).

        //ani = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

    //    thisRenderer = GetComponent<SpriteRenderer>();
        //8-6-19
        //how to properly change animations. You need to do some fanagling inside of the unity editor to get this to work... can't just be script side
        ani = this.GetComponent<Animator>();
        ani.SetBool("ISDESTROYED", false);
//        if (thisRenderer)

   //     {
   //
     //       Shader _swapShader = Shader.Find("Custom/SwapTwo");

       //     if (!_swapShader)

         //   {

           //     Debug.LogError("You dont have shader... ");

           // }

          //  else

          //  {

            ///    Material _newMat = new Material(_swapShader);
            //
              //  thisRenderer.material = _newMat;

                //thisRenderer.material.SetTexture("_MainTex2", swappedTexture);

           // }

       /// }

       // else

       /// {

         //   Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);

       /// }



    }
    float speed = 100;
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x<200)
        {
            rb.AddForce(new Vector2(speed, 0));
        }

        GameObject MastCont = GameObject.Find("PlayerShip");
           Transform playerLoc = MastCont.GetComponent<Transform>();
        //the only way for this ship to be defeated is to 
        if ((Mathf.RoundToInt(playerLoc.transform.position.x) == Mathf.RoundToInt(this.transform.position.x)) && (shotPerScreenbump==false))
        {
            shotPerScreenbump = true;
            GameObject PoopPEE = Instantiate(Resources.Load("koshoot")) as GameObject;
            PoopPEE.name = "FART";
            PoopPEE.transform.rotation = transform.rotation;
            Rigidbody2D fun = PoopPEE.GetComponent<Rigidbody2D>();
            fun.AddForce(rb.velocity); //match the speed
            PoopPEE.transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, 0);// + (transform.up);
        }

        if (hp < 0)
        {
            ani.SetBool("ISDESTROYED", true);
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("BlowUp") &&
ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

        if (Time.time > nextUsage) //delete otherwise
        {
            //   this.transform.localScale = transform.localScale * 2;
            if (hp<100)
            {
                hp = hp + 1;
            }
           // transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
            nextUsage = Time.time + delay; //it is on display

        }

    }
    //this is to handle running into an object blocking the objects path
   // private void LateUpdate()
   // {
     //   if (swappedTexture != null)

//        {
//
  //          SwapTexture(swappedTexture);

    //        swappedTexture = null;

      //  }
   // }

    //https://github.com/RetryEntry/UnityAnimatorChangeSprite/blob/master/SwappedTextures.cs


  //  public void SwapTexture(Texture2D _toWhat)

    //{

      //  swappedTexture = _toWhat;

        //if (thisRenderer)

//        {

  //          Shader _swapShader = Shader.Find("Custom/SwapTwo");
  //
    //        if (!_swapShader)

      //      {

        //        Debug.LogError("You dont have shader... ");

          //  }

            //else

          //  {

            //    Material _newMat = new Material(_swapShader);

              //  thisRenderer.material = _newMat;

                //thisRenderer.material.SetTexture("_MainTex2", swappedTexture);

           // }

       // }

      //  else

        //{

          //  Debug.LogError("There is NO spriterenderer attached to gameobject " + this.name);

       /// }

    //}
    //https://gamedev.stackexchange.com/questions/72765/change-the-sprite-of-a-object-in-unity
 //   void ChangeThecookie!Sprite()
  //  {
 //       if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
 //       {
 //           spriteRenderer.sprite = sprite2;
  //          ani1.Play();
  //      }
  //      else
   //     {
   //         spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
       //     ani2.Play();
       // }
  //  }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /* var direction = transform.InverseTransformPoint(other.transform.position); //this helps us find which direction the object collided from

         if (direction.x > 0f)
         { 
             //Debug.Log("Go left now");
             speed = -50;
         }
         else if (direction.x < 0f)
         {
            // Debug.Log("Go right now");
             speed = 50;
         }
         */
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            if (other.otherRigidbody.velocity.magnitude > .05f) //(other.collider.velocity.magnitude > 100)
            {

                //         if (ani.GetCurrentAnimatorStateInfo(0).IsName("swissCheese") &&
                //ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                //   ChangeThecookie!Sprite(); // call method to change sprite
                hp = hp - 5;
                //  Debug.Log("HIT");

                shotPerScreenbump = true;
                GameObject PoopPEE = Instantiate(Resources.Load("koshoot")) as GameObject;
                PoopPEE.name = "FART";
                PoopPEE.transform.rotation = transform.rotation;
                Rigidbody2D fun = PoopPEE.GetComponent<Rigidbody2D>();
                fun.AddForce(rb.velocity); //match the speed
                PoopPEE.transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, 0);// + (transform.up);
                //  Destroy(this.gameObject);
            }
          
           
        }
        else
        {
            if (other.otherRigidbody.velocity.magnitude > 2) //(other.collider.velocity.magnitude > 100)
            {
                hp = hp - 1;
             
            }
            else if (other.gameObject.CompareTag("IndestShot"))
            {
                hp = hp - 55;
            }
        }
            try
        {
            if ((this.transform.position.x - other.collider.transform.position.x) < 0)
            {
                //  shotPerScreenbump = false; //reset the ability to shoot again the player or themselves :)
                // print("hit left");
                if ((!other.gameObject.CompareTag("SpaceJunk")) || (!other.gameObject.CompareTag("PlayerShot")))
                {
                   // Debug.Log("Go LEFT now");
                    rb.velocity = Vector3.zero;
                    speed = -100;
                    shotPerScreenbump = false;
                }
               
            }
            else if ((this.transform.position.x - other.collider.transform.position.x) > 0)
            {
                // shotPerScreenbump = false; //reset the ability to shoot again the player or themselves :)
                //  print("hit right");
                if ((!other.gameObject.CompareTag("SpaceJunk")) || (!other.gameObject.CompareTag("PlayerShot")))
                {
                    rb.velocity = Vector3.zero;
                    speed = 100;
                    shotPerScreenbump = false;
                    // Debug.Log("Go RIGHT now");
                }
            }
        }
        catch //the collider is not the most common box collider
        {
            if ((this.transform.position.x - other.collider.transform.position.x) < 0)
            {
                //   shotPerScreenbump = false; //reset the ability to shoot again the player or themselves :)
                // print("hit left");
                if ((!other.gameObject.CompareTag("SpaceJunk")) || (!other.gameObject.CompareTag("PlayerShot")))
                {
                   // Debug.Log("Go LEFT now");
                    speed = -100;
                    rb.velocity = Vector3.zero;
                    shotPerScreenbump = false;
                }
            }
            else if ((this.transform.position.x - other.collider.transform.position.x) > 0)
            {
                //  shotPerScreenbump = false; //reset the ability to shoot again the player or themselves :)
                //  print("hit right");
                if ((!other.gameObject.CompareTag("SpaceJunk")) || (!other.gameObject.CompareTag("PlayerShot")))
                {
                    speed = 100;
                    // Debug.Log("Go RIGHT now");
                    rb.velocity = Vector3.zero;
                    shotPerScreenbump = false;
                }
            }
        }




    }

        //modified for uss potetoe, COPY elsewhere (ie enemyBoxGas.cs)
        //this is default method for screen wrapping as of 7-16-19
        //older version does exist relying on even further out collision points
        float fartX = 0.0f;
    float fartY = 0.0f;
    private void OnTriggerStay2D(Collider2D other)
    {

        

        try
        {
            //     Vector3 screenPoint = this.leftCamera.WorldToViewportPoint(targetPoint.position);
            // bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (GetComponent<Renderer>().isVisible)
            //  {
            //   if (m_Renderer.isVisible)
            {
              //  //debug.log("object is visible");
            }
            else
            {
                //   Debug.Log("CurVelocityX:" + rb.velocity.x);
                //   Debug.Log("CurVelocityY:" + rb.velocity.y);
                //object is off the screen so we can move to the bottom
                GameObject Cam = GameObject.Find("Main Camera");
                Transform ff = Cam.GetComponent<Transform>();



              


                //   transform.position = new Vector2(ff.position.x, ff.position.y);
                if (rb.velocity.x > 0 && other.gameObject.CompareTag("East")) //moving foward
                {
                    fartX = -(transform.position.x - .15f);
                    fartY = (transform.position.y);
                }
             else   if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
                {
                    fartX = -(transform.position.x + .15f);
                    fartY = (transform.position.y);
                }
                if (other.gameObject.CompareTag("North")) //moving up
                {
                    fartY = -(transform.position.y - .05f);
                    fartX = (transform.position.x);
                }
              else  if (other.gameObject.CompareTag("South"))//going down
                {
                    fartY = -(transform.position.y + .05f);
                    fartX = (transform.position.x);
                }
                /*
                GameObject PoopPEE = Instantiate(Resources.Load(gameObject.name)) as GameObject;
                PoopPEE.name = gameObject.name;
                PoopPEE.transform.rotation = transform.rotation;
                Rigidbody2D fun = PoopPEE.GetComponent<Rigidbody2D>();
                fun.AddForce(rb.velocity); //match the speed
                PoopPEE.transform.position = new Vector3(fartX,fartY,0) + (transform.up);
                */

              if (fartY== (transform.position.y) || fartY == -(transform.position.y)) //we want to go down by one
                {
                    //we want to move the object down the screen
                    var renderer2 = this.GetComponent<Renderer>();
                    float height = renderer2.bounds.size.y;

                    fartY = transform.position.y - height;
                    shotPerScreenbump = false; //reset the ability to shoot again the player or themselves :)
                }
                if (fartX != 0 || fartY != 0)
                {
                    transform.position = new Vector2(fartX, fartY);
                   
                }

                // Debug.Log("Object is no longer visible");
                //  Debug.Log("X:" + fartX + "Y:" + fartY);
                fartX = 0.0f;
                fartY = 0.0f;

            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }


    }
}
