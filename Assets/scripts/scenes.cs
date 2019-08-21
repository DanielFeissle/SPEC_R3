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
    //    Debug.Log("SystemRand degreeCnt" + directionChoice);
        int rotCnt = (blarg.Next(0, 36));
     //   Debug.Log("Rand degreeCnt" + rotCnt);
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
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas<25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas<50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas<75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
            }
            else if (fundas<100)
            {
                GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                ExpDust.name = "StdWall";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
            }
          
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
            if (x == 0)
            {
                ShipLeft = moveX;
                //     shipTop = moveY;
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
                if (x == 0)
                {
                    ShipLeft = moveX;
                    //     shipTop = moveY;
                }
                if (x == shipX - 1)
                {
                    ShipRight = moveX;
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
                    shipTop = moveY;
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
                ShipRight = moveX;
           //     shipTop = moveY;
            }
            if (x == 0)
            {
                ShipLeft = moveX;
                //     shipTop = moveY;
            }

            if (stupY==0)
            {
                shipBottom = moveY;
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
                    if (x == 0)
                    {
                        ShipLeft = moveX;
                        //     shipTop = moveY;
                    }
                    //we decide if this is the end (left or right)
                    if (x == shipX - 1)
                    {
                        ShipRight = moveX;
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
                      
                            shipBottom = moveY;
                        
                        dumbnut2 = fud.transform.position.y; //bottom
                    }
                    if (y == shipY - 1)
                    {
                        shipTop = moveY;
                        fud.transform.position = new Vector2((moveX ), (moveY + width / 2));
                        dumbnut = fud.transform.position.y; //top
                        if (shipY == 1)//only one column
                        {
                            GameObject fud3 = Instantiate(Resources.Load("dertypShips\\shipHull - Flat")) as GameObject;
                            fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                            fud3.transform.position = new Vector2((moveX), (moveY - width / 2));
                            posX = fud3.transform.position.x;
                            posY = fud3.transform.position.y;
                            shipTop = moveY;

                        }
                    }
                    else if(x == shipX - 1)
                    {
                        ShipLeft = moveX;
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
                if (y == shipY-1) //- 1)
                {
                    shipTop = moveY;
                }
                if (y == 0)
                {
                    shipBottom = moveY;
                }

                moveY = shipTest2.GetComponent<Renderer>().bounds.size.y + moveY;

              
              
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
            shipTestTop.transform.position = new Vector2(ShipRight+ shipTestTop.GetComponent<Renderer>().bounds.size.x, (UnityEngine.Random.Range(shipBottom, shipTop)));//  shipTestTop.transform.position = new Vector2(ShipRight+ shipTestTop.GetComponent<Renderer>().bounds.size.x, (shipTop-shipBottom/2)); //(shipTop-shipBottom/2)
            shipTestTop.transform.Rotate(0, 0, -90 * 1);
        
            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.x;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2(LeftDoor.transform.position.x - width, (UnityEngine.Random.Range(shipBottom, shipTop))); //   shipbehind.transform.position = new Vector2(LeftDoor.transform.position.x - width, (shipTop - shipBottom / 2));
            shipbehind.transform.Rotate(0, 0, -90 * 1);
            //new random size for tops/bottoms 7-28-19
            float herdir = UnityEngine.Random.Range(-.05f, 0.5f); //  float herdir=  UnityEngine.Random.Range(shipBottom, shipTop);
            shipbehind.transform.localScale += new Vector3(herdir, 0, 0);
            shipTestTop.transform.localScale += new Vector3(herdir, 0, 0);
        }
     else if (shipY>shipX) //vertical ship
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(UnityEngine.Random.Range(ShipLeft, ShipRight), shipTop + shipTestTop.GetComponent<Renderer>().bounds.size.y); //   shipTestTop.transform.position = new Vector2(Mathf.Abs((ShipRight - ShipLeft) / 2), shipTop + shipTestTop.GetComponent<Renderer>().bounds.size.y);

            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2((UnityEngine.Random.Range(ShipLeft, ShipRight)), LeftDoor.transform.position.y - width);  // shipbehind.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor.transform.position.y - width);

            //new random size for tops/bottoms 7-28-19
            float herdir = UnityEngine.Random.Range(-.05f, 0.5f); // float herdir = UnityEngine.Random.Range(ShipLeft, ShipRight);
            shipbehind.transform.localScale += new Vector3(herdir, 0, 0);
            shipTestTop.transform.localScale += new Vector3(herdir, 0, 0);

            /*
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2((ShipRight-ShipLeft/2), shipTop);


            GameObject LeftDoor = GameObject.Find("shipHull(1"  + "," +  "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor.transform.position.y-width);
            */

        }
     else //they are equal and does not matter where
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(UnityEngine.Random.Range(ShipLeft, ShipRight), shipTop+ shipTestTop.GetComponent<Renderer>().bounds.size.y); // shipTestTop.transform.position = new Vector2(((ShipRight - ShipLeft) / 2), shipTop+ shipTestTop.GetComponent<Renderer>().bounds.size.y);

            GameObject LeftDoor = GameObject.Find("shipHull(1" +  "," +  "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2(UnityEngine.Random.Range(ShipLeft, ShipRight), LeftDoor.transform.position.y - width);  //  shipbehind.transform.position = new Vector2(Mathf.Abs(ShipRight - ShipLeft / 2), LeftDoor.transform.position.y - width);



            //new random size for tops/bottoms 7-28-19
            float herdir = UnityEngine.Random.Range(-.05f, 0.5f); //    float herdir = UnityEngine.Random.Range(ShipLeft, ShipRight);
            shipbehind.transform.localScale += new Vector3(herdir, 0, 0);
            shipTestTop.transform.localScale += new Vector3(herdir, 0, 0);
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
        //  Debug.Log("herder value" + herder);

        //now we want to put angle'd ship stuff in



     
      


        GameObject shipbehind44 = Instantiate(Resources.Load("dertypShips\\diag")) as GameObject;
        var renderer44 = shipbehind44.GetComponent<Renderer>();
        float width44 = renderer44.bounds.size.x;
        float height44 = renderer44.bounds.size.y;
        shipbehind44.name = "dertypShips\\diag";
        // shipbehind44.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor44.transform.position.y - width44);
        shipbehind44.transform.position = new Vector2(ShipRight+(width44), shipTop+(height44));

        //ship back/bottom top or if horizantal- up left
        GameObject shipbehind544 = Instantiate(Resources.Load("dertypShips\\diag")) as GameObject;
        var renderer544 = shipbehind544.GetComponent<Renderer>();
        float width544 = renderer544.bounds.size.x;
        float height544 = renderer544.bounds.size.y;
        shipbehind544.name = "dertypShips\\diagLEFT";
        shipbehind544.transform.position = new Vector2(ShipLeft - (width544), shipTop + (height544*1.25f));


        GameObject shipbehind344 = Instantiate(Resources.Load("dertypShips\\diag")) as GameObject;
        var renderer344 = shipbehind344.GetComponent<Renderer>();
        float width344 = renderer344.bounds.size.x;
        float height344 = renderer344.bounds.size.y;
        shipbehind344.name = "dertypShips\\diagRIGHT";
        shipbehind344.transform.position = new Vector2(ShipRight + (width344), shipBottom - (height344));




        GameObject shipbehind244 = Instantiate(Resources.Load("dertypShips\\diag")) as GameObject;
        var renderer244 = shipbehind344.GetComponent<Renderer>();
        float width244 = renderer244.bounds.size.x;
        float height244 = renderer244.bounds.size.y;
        shipbehind244.name = "dertypShips\\diagumIdontKnow";
        shipbehind244.transform.position = new Vector2(ShipLeft - (width244), shipBottom - (height244*1.25f));

        shipbehind44.transform.rotation = Quaternion.Euler(new Vector3(0f,180.0f, 0.0f));

        shipbehind344.transform.rotation = Quaternion.Euler(new Vector3(0f, 0.0f, 180.0f));

        shipbehind244.transform.rotation = Quaternion.Euler(new Vector3(0f, 0.0f, 0.0f));
        //if vertl is false, then we are wide and laying down otherwise if true then we are vertical
        if (vertl == false)
        {
            shipbehind44.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90.0f));

            shipbehind544.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 270.0f));

            shipbehind344.transform.rotation = Quaternion.Euler(new Vector3(0f, 180.0f, 270.0f));

            shipbehind244.transform.rotation = Quaternion.Euler(new Vector3(0f, 180.0f, -90.0f));
        }
        //   GameObject MastCont = GameObject.Find("PlayerShip");
        //   MasterController backEnd = MastCont.GetComponent<MasterController>();
        //descide how many special enemies should be spawned in
        //these enemies are described as
        //baderang      4
        //nutdude       7
        //usspotetoe    1
        int baderang = 0;
        int nutdud = 0;
        int usspotetoe = 0;
      int enemyApperanceChance=  UnityEngine.Random.Range(0, backEnd.level);
        int howmanyenemies= UnityEngine.Random.Range(1, 15); //we will only let 12 different aggressive enemies be on screen at a given time in addition to the asteroids/stuff
        if (enemyApperanceChance>(backEnd.level/2)) //+5
        {
            //boom you got random enemies spawning in
            for (int i=0;i<howmanyenemies;i++)
            {
                GameObject smrtEnemy;
                int randEnemyType = UnityEngine.Random.Range(0, 100);
                if (randEnemyType<33 && usspotetoe<1)
                {
                    usspotetoe++;
                     smrtEnemy = Instantiate(Resources.Load("kusspottetoe")) as GameObject;
                    smrtEnemy.name = "usspoteto_0";
                    smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                    smrtEnemy.transform.position = new Vector2(0, 0);
                }
                else if (randEnemyType<66 && baderang<4)
                {
                    baderang++;
                     smrtEnemy = Instantiate(Resources.Load("faterang")) as GameObject;
                    smrtEnemy.name = "dertypShips\\baderang";
                    smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                    smrtEnemy.transform.position = new Vector2(0, 0);
                }
                else
                {
                    nutdud++;
                     smrtEnemy = Instantiate(Resources.Load("dud")) as GameObject;
                    smrtEnemy.name = "dertypShips\\dud";
                    smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                    smrtEnemy.transform.position = new Vector2(0, 0);
                }

              
                Vector3 spawnPoint = smrtEnemy.transform.position;
                //    var hitColliders = Physics.OverlapSphere(spawnPoint, 1);//1 is purely chosen arbitrarly
                // var hitf = Physics2D.OverlapArea(spawnPoint, 2.0f);

                // Find all colliders that overlap
                PolygonCollider2D myCollider = smrtEnemy.GetComponent<PolygonCollider2D>();
                Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);

                // Check for any colliders that are on top
                bool isUnderneath = false;
              //  foreach (var otherCollider in otherColliders)
                //{
                    
                    if (otherColliders.Length>1) //    if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                    {
                        isUnderneath = true;
                        while ((isUnderneath)) //You have someone with a collider here
                        {
                            smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                        if (otherColliders.Length > 1)//  if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                        {
                                isUnderneath = false;
                            }
                        }
                     //   break;
                    }
                //}

                // Take the appropriate action
                /*    if (!isUnderneath)
                    {
                        Debug.Log("HOORAY!");
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        Debug.Log("OOPS!");
                    }
                    */

                /*
                                while ((isUnderneath)) //You have someone with a collider here
                                {
                                     isUnderneath = false;
                                    //regenerate 
                                    Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFRegenerate spawn location at" + Time.time.ToString());
                                    smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                                    foreach (var otherCollider in otherColliders)
                                    {
                                        if (otherCollider.transform.position.z < this.transform.position.z)
                                        {
                                            isUnderneath = true;

                                        }
                                    }
                                } */
            }

            //   sweedy.transform.position = GameObject.Find("WestTrigger").transform.position;
        }


    }

    // Update is called once per fram
    void Update () {
		
	}

    
}
