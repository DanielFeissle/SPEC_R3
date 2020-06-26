using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class payerControl : MonoBehaviour {

    //this is sort of a stats collecting for 
 public   float PlayerMoney = 0.00f;
    public float PlayerMoneyLeft = 0.00f;
    public float PlayerMoneyRight = 0.00f;
    public float PlayerMoneyUp = 0.00f;
    public float PlayerMoneyShot = 0.00f;
    Scene m_Scene;
    string sceneName;
    bool controlerUsed = false;
    float nextUsage;
    float delay = 0.15f; //only half delay
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void Awake()
    {
        
    }




    public float moveHorizantal;
    public float moveVertical;
    private void FixedUpdate()
    {
        GameObject transportShip = GameObject.Find("transportShip");
        masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();

        if (introShip.introScene == false) //enable standard game rules
        {

      


        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if (sceneName.Contains("stage"))
        {


         
          
            if (Time.time > 4 && introShip.introScene == false)
            {
                moveVertical = 0;
                // Debug.Log("Controller" + controlerUsed);
                if (controlerUsed == false)
                {
                    moveVertical = Input.GetAxis("Vertical");
                        if (moveVertical!=0)
                        {
                            PlayerMoneyUp= PlayerMoneyUp + 0.0025f;
                            PlayerMoney = PlayerMoney + 0.0025f;
                        }
                    //   
                }

                moveHorizantal = Input.GetAxis("Horizontal");

                //if (Input.GetButtonDown("360_RightBumper"))
                float TriggerRight = Input.GetAxis("Cont_Trigger");
                //   Debug.Log("Your Value for Trigger is " + TriggerRight);
                if (TriggerRight != 0) //controller support
                {
                    moveVertical = TriggerRight * -1;
                        if (moveVertical != 0)
                        {
                            PlayerMoneyUp = PlayerMoneyUp + 0.0025f;
                            PlayerMoney = PlayerMoney + 0.0025f;
                        }
                    }

                moveHorizantal = moveHorizantal * 2;
                if (moveHorizantal > 0)
                {
                        PlayerMoneyRight = PlayerMoneyRight + 0.001f;
                        //rb.velocity = Vector3.zero;
                        PlayerMoney = PlayerMoney + 0.001f;
                    }
                else if (moveHorizantal < 0)
                {
                        PlayerMoneyLeft = PlayerMoneyLeft + 0.001f;
                        PlayerMoney = PlayerMoney + 0.001f;
                        // rb.velocity = Vector3.zero;
                    }
           
               



                if (Input.GetButton("Fire1"))
                {
                    if (Time.time > nextUsage) //delete otherwise
                    {
                            PlayerMoney = PlayerMoney + 0.005f;
                            PlayerMoneyShot= PlayerMoneyShot+ 0.005f;
                            nextUsage = Time.time + delay; //it is on display
                    }

                }
            }
        }
    }
    }

}
