using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes : MonoBehaviour {

    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    void  interiorShip(float moveX, float moveY, float width4)
    {

        Sprite pauseSprite = Resources.Load<Sprite>("interhull_faded(256x64)");


        GameObject dershi = Instantiate(Resources.Load("dertypShips\\interhullA")) as GameObject;
        objResourceNameHold fudg = dershi.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
        fudg.objName = "dertypShips\\interhullA";
        dershi.name = "interiorWall(" + moveX + "," + moveY + ")";
        dershi.transform.position = new Vector2((moveX), (moveY - width4/2));
        Debug.Log("Wiedth is " + width4);




        int directionChoice = randomDirection.Next(0, 37);
        Debug.Log("SystemRand degreeCnt" + directionChoice);
        int rotCnt = (blarg.Next(0, 36));
        Debug.Log("Rand degreeCnt" + rotCnt);
        float degreeCnt = 0;
        for (int i = 0; i < directionChoice; i++)
        {
            degreeCnt = degreeCnt + 10.0f;
        }
        float yRotation = degreeCnt;
        //   Renderer[] renderers = GetComponentsInChildren<Renderer>();
       
        Renderer renderers = dershi.GetComponent<Renderer>();
        //  gameObject.GetComponent<Renderer>().material.color = Color.green;

        dershi.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, yRotation);

    }

    // Use this for initialization
    void Start () {
        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();
        for (int i = 0; i < backEnd.level; i++)
        {
            GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
            ExpDust.name = "AstMan2019";
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
        }
        /*
        GameObject MastCont = GameObject.Find(gameObject.name);
        MasterController backEnd = MastCont.GetComponent<MasterController>();
        if (backEnd.level==0) //load the player in the screen
        {
            GameObject PoopPEE = Instantiate(Resources.Load("PlayerShip")) as GameObject;
            PoopPEE.name = "PlayerShip";
            PoopPEE.transform.position = new Vector2(-0.0f, -5.0f);
        }
        */

        Debug.Log("HI THERE");
        //deriship spawner 4-28-19
        float startX = -4;
        float startY = -2.5f;

        float moveX = startX;
        float moveY = startY;
        Debug.Log("LOL");
        //first decide the orientation, up down left or right
      int shipiOri=  UnityEngine.Random.Range(1, 4);
        if (shipiOri==1)
        {
            shipiOri = 0;

        }
        else if (shipiOri==2)
        {
            shipiOri = 90;
        }
        else if (shipiOri==3)
        {
            shipiOri = 180;
        }
        else //catch everything else to be leftward facing
        {
            shipiOri = 270;
        }

        //next decide the total size of the ship
        int shipX = UnityEngine.Random.Range(1, 4);
        int shipY = UnityEngine.Random.Range(1, 4);
        bool vertl = true;
        if (shipX>shipY)
        {
            vertl = false; //we are wide
        }
        //now we got the intial stuff, now loop through the sizes
        int stupY = 1;
        int stupX = 1;
        float shipTop, shipBottom, ShipLeft, ShipRight;
        shipTop = 0;
        ShipRight = 0;
        shipBottom = shipY;
        ShipLeft = shipX;
        float dumbnut = 0;
        float dumbnut2 = 0;
        for (int x=0; x<shipX;x++)
        {
            if (x == shipX - 1)
            {
                ShipRight = moveX;
            }
            stupY = 0;
            GameObject shipTest = Instantiate(Resources.Load("dertypShips\\genericBack")) as GameObject;
            objResourceNameHold fudg= shipTest.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
            fudg.objName = "dertypShips\\genericBack";
            shipTest.name = "genericBack(" + stupX + "," + stupY +")";
            shipTest.transform.position = new Vector2(moveX, moveY);
            posXarr[x] = moveX;
            posYarr[stupY] = moveY;

            var renderer4 = shipTest.GetComponent<Renderer>();
            float width4 = renderer4.bounds.size.x;
            interiorShip(moveX, moveY, width4);


            //we decide if this is the end (left or right)
            //  if (x==0)
            //*  {
            if (vertl==true)
            {
                GameObject fud2 = Instantiate(Resources.Load("dertypShips\\shipHull")) as GameObject;
                 fudg = fud2.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
                fudg.objName = "dertypShips\\shipHull";
                fud2.name = "shipHull(" + stupX + "," + stupY + ")";
                var renderer2 = shipTest.GetComponent<Renderer>();
                float width2 = renderer2.bounds.size.x;
                if (x == shipX - 1)
                {
                    fud2.transform.position = new Vector2((moveX + width2 / 2), moveY);
                    if (shipX==1)//only one column
                    {
                        GameObject fud3 = Instantiate(Resources.Load("dertypShips\\shipHull")) as GameObject;
                        fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                        fud3.transform.position = new Vector2((moveX - width2 / 2), moveY);

                    }
                }
                else
                {
                    fud2.transform.position = new Vector2((moveX - width2 / 2), moveY);
                }

                shipTest.transform.parent = fud2.transform; //how do I put a parent with a child prefab, this is how!
            }
         else
            {
                GameObject fud2 = Instantiate(Resources.Load("dertypShips\\shipHull - Flat")) as GameObject;
                fud2.name = "shipHull(" + stupX + "," + stupY + ")";
                var renderer2 = shipTest.GetComponent<Renderer>();
                float width2 = renderer2.bounds.size.y;
                if (stupY == shipY - 1)
                {
                    fud2.transform.position = new Vector2((moveX), (moveY + width2 / 2));
                    if (shipY == 1)//only one column
                    {
                        GameObject fud3 = Instantiate(Resources.Load("dertypShips\\shipHull - Flat")) as GameObject;
                        fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                        fud3.transform.position = new Vector2((moveX), (moveY - width2 / 2));

                    }
                }
                else
                {
                    fud2.transform.position = new Vector2((moveX), (moveY - width2 / 2));
                }

                shipTest.transform.parent = fud2.transform; //how do I put a parent with a child prefab, this is how!
            }
            if (x == shipX - 1)
            {
           //     shipTop = moveY;
            }

            Debug.Log("shipY" + shipY);

            //     }


            //  moveY = shipTest.GetComponent<Renderer>().bounds.size.y + moveY;
            Debug.Log("Your MOVE" + shipTest.GetComponent<Renderer>().bounds.size.x);

            //old dummy way:
            //  shipTest.GetComponent<Collider2D>().bounds.size.x
            moveY = shipTest.GetComponent<Renderer>().bounds.size.y + moveY;
            for (int y = 1; y < shipY; y++)
            {
                float posX = 0;
                float posY = 0;
                stupY++;
                GameObject shipTest2 = Instantiate(Resources.Load("dertypShips\\genericBack")) as GameObject;
                shipTest2.name = "genericBack(" + stupX + "," + stupY + ")";
                shipTest2.transform.position = new Vector2(moveX, moveY);

             //we only need the size of one box, since all the shapes are uniform It won't matter as much
                interiorShip(moveX, moveY, width4);

                posXarr[x] = moveX;
                posYarr[stupY] = moveY;
                if (vertl == true)
                {
                    GameObject fud = Instantiate(Resources.Load("dertypShips\\shipHull")) as GameObject;
                    fud.name = "shipHull(" + stupX + "," + stupY + ")";
                    var renderer = shipTest2.GetComponent<Renderer>();
                    float width = renderer.bounds.size.x;
                    //we decide if this is the end (left or right)
                    if (x == shipX - 1)
                    {
                        fud.transform.position = new Vector2((moveX + width / 2), (moveY));
                        if (shipX == 1)//only one column
                        {
                            GameObject fud3 = Instantiate(Resources.Load("dertypShips\\shipHull")) as GameObject;
                            fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                            fud3.transform.position = new Vector2((moveX - width / 2), moveY);
                            posX = fud3.transform.position.x;
                            posY = fud3.transform.position.y;

                        }
                    }
                    else
                    {
                        fud.transform.position = new Vector2((moveX - width / 2), (moveY ));
                    }
                  

                    shipTest2.transform.parent = fud.transform; //how do I put a parent with a child prefab, this is how!
                }
                else
                {
                    GameObject fud = Instantiate(Resources.Load("dertypShips\\shipHull - Flat")) as GameObject;
                    fud.name = "shipHull(" + stupX + "," + stupY + ")";
                    var renderer = shipTest2.GetComponent<Renderer>();
                    float width = renderer.bounds.size.y;
                    //we decide if this is the end (left or right)
                    if (y==0)
                    {
                        dumbnut2 = fud.transform.position.y; //bottom
                    }
                    if (y == shipY - 1)
                    {
                      
                        fud.transform.position = new Vector2((moveX ), (moveY + width / 2));
                        dumbnut = fud.transform.position.y; //top
                        if (shipY == 1)//only one column
                        {
                            GameObject fud3 = Instantiate(Resources.Load("dertypShips\\shipHull - Flat")) as GameObject;
                            fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                            fud3.transform.position = new Vector2((moveX), (moveY - width / 2));
                            posX = fud3.transform.position.x;
                            posY = fud3.transform.position.y;
                           
                        }
                    }
                    else
                    {
                        fud.transform.position = new Vector2((moveX ), (moveY + width / 2));
                    }
                    if (stupY == 1 && packageLoad==false)
                    {
                        if (stupX == 1)
                        {

                        }
                    }

                    shipTest2.transform.parent = fud.transform; //how do I put a parent with a child prefab, this is how!
                }
            
                moveY = shipTest2.GetComponent<Renderer>().bounds.size.y + moveY;

                if (y == shipY - 1)
                {
                    shipTop = moveY;
                }
              
                Debug.Log("shipY" + shipY);
              
               
            
               // GameObject LeftDoor = GameObject.Find("genericBack(" + stupX + "," + stupY + ")");
               // Transform LeftFound = LeftDoor.GetComponent<Transform>();
              
            }
            moveX = shipTest.GetComponent<Renderer>().bounds.size.x + moveX;
            stupX++;
            moveY = startY;
        }
      //  ShipRight = moveX;
     //   shipTop = moveY;
        //    moveX = startX;
        //now we want to get the orientation and put the top and bottom parts of the ship togather
        Debug.Log("Top:"+shipTop+ "Bottom:" + shipBottom + "Left:" + ShipLeft + "Right:" + ShipRight);


        if (shipX>shipY) //horizontal ship
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(ShipRight+ shipTestTop.GetComponent<Renderer>().bounds.size.x, (shipTop-shipBottom/2));
            shipTestTop.transform.Rotate(0, 0, -90 * 1);
        
            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.x;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2(LeftDoor.transform.position.x - width, (shipTop - shipBottom / 2));
            shipbehind.transform.Rotate(0, 0, -90 * 1);
        }
     else if (shipY>shipX) //vertical ship
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2((ShipRight-ShipLeft/2), shipTop);


            GameObject LeftDoor = GameObject.Find("shipHull(1"  + "," +  "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor.transform.position.y-width);
          
        }
     else //they are equal and does not matter where
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(((ShipRight - ShipLeft) / 2), shipTop+ shipTestTop.GetComponent<Renderer>().bounds.size.y);

            GameObject LeftDoor = GameObject.Find("shipHull(1" +  "," +  "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor.transform.position.y - width);
        }

        if ( packageLoad == false)
        {
           // if (stupX == 1)
          //  {
                GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\caseShip")) as GameObject;
                fud5323.name = "thePackage(" + stupX + "," + stupY + ")";
                fud5323.transform.position = new Vector2((posXarr[0]+.35f), (posYarr[0]));
            GameObject fud53233 = Instantiate(Resources.Load("dertypShips\\casePipes")) as GameObject;
            fud53233.name = "thePackage2(" + stupX + "," + stupY + ")";
            fud53233.transform.position = new Vector2((posXarr[0]), (posYarr[0]+.35f));
            GameObject fud54323 = Instantiate(Resources.Load("dertypShips\\caseGlass")) as GameObject;
            fud54323.name = "thePackage3(" + stupX + "," + stupY + ")";
            fud54323.transform.position = new Vector2((posXarr[0]), (posYarr[0]-.35f));
            GameObject fud53523 = Instantiate(Resources.Load("dertypShips\\casePlain")) as GameObject;
            fud53523.name = "thePackage4(" + stupX + "," + stupY + ")";
            fud53523.transform.position = new Vector2((posXarr[0]-.35f), (posYarr[0]));
            packageLoad = true;
         //  }
        }


        //6-17-19 we want to add junk  
        //  ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
        int herder=UnityEngine.Random.Range(10, 20); //we get the count of how many random objects we want to put in
        
        for (int i=0; i< herder;i++)
        {
            //zero always exists , it is where the package is
            float derptyX, derptyY;
            derptyX= UnityEngine.Random.Range(posXarr[0]-1.75f, posXarr[shipX-1] + 1.75f);
            derptyY = UnityEngine.Random.Range(posYarr[0]-1.75f, posYarr[shipY-1] + 1.75f);

            GameObject dershi = Instantiate(Resources.Load("shipDebris\\nucWaste")) as GameObject;
            dershi.name = "nucWaste(" + derptyX + "," + derptyY + ")";
            dershi.transform.position = new Vector2((derptyX), (derptyY - .35f));

            
        }
        Debug.Log("herder value" + herder);
    }

    // Update is called once per fram
    void Update () {
		
	}

    
}
