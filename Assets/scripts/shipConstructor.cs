﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipConstructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //12-16-19
    //this is a experiment taking the orginal code of the scens ship
    //and putting it in the overworld by calling it from another script
    //making this become more modular and or independent/easier to read or use in the future
    //your welcome ~past dan

    public void constructThis(float truStartX, float truStartY)
    {
        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

    //    Debug.Log("HI THERE");
        //deriship spawner 4-28-19
        float startX = truStartX;//-4;
        float startY = truStartY; //-2.5f;

        float moveX = startX;
        float moveY = startY;
        //first decide the orientation, up down left or right
        int shipiOri = UnityEngine.Random.Range(1, 4);
        if (shipiOri == 1)
        {
            shipiOri = 0;

        }
        else if (shipiOri == 2)
        {
            shipiOri = 90;
        }
        else if (shipiOri == 3)
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
        if (shipX > shipY)
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
        for (int x = 0; x < shipX; x++)
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
            objResourceNameHold fudg = shipTest.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
            fudg.objName = "dertypShips\\genericBack";
            shipTest.name = "genericBack(" + stupX + "," + stupY + ")";
            shipTest.transform.position = new Vector2(moveX, moveY);
            posXarr[x] = moveX;
            posYarr[stupY] = moveY;

            var renderer4 = shipTest.GetComponent<Renderer>();
            float width4 = renderer4.bounds.size.x;
            interiorShip(moveX, moveY, width4);


            //we decide if this is the end (left or right)
            //  if (x==0)
            //*  {
            if (vertl == true)
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
                    if (shipX == 1)//only one column
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

            if (stupY == 0)
            {
                shipBottom = moveY;
            }

        //    Debug.Log("shipY" + shipY);

            //     }


            //  moveY = shipTest.GetComponent<Renderer>().bounds.size.y + moveY;
         //   Debug.Log("Your MOVE" + shipTest.GetComponent<Renderer>().bounds.size.x);

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
                        fud.transform.position = new Vector2((moveX - width / 2), (moveY));
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
                    if (y == 0)
                    {

                        shipBottom = moveY;

                        dumbnut2 = fud.transform.position.y; //bottom
                    }
                    if (y == shipY - 1)
                    {
                        shipTop = moveY;
                        fud.transform.position = new Vector2((moveX), (moveY + width / 2));
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
                    else if (x == shipX - 1)
                    {
                        ShipLeft = moveX;
                        fud.transform.position = new Vector2((moveX), (moveY + width / 2));
                    }
                   

                    shipTest2.transform.parent = fud.transform; //how do I put a parent with a child prefab, this is how!
                }
                if (y == shipY - 1) //- 1)
                {
                    shipTop = moveY;
                }
                if (y == 0)
                {
                    shipBottom = moveY;
                }

                moveY = shipTest2.GetComponent<Renderer>().bounds.size.y + moveY;



            //    Debug.Log("shipY" + shipY);



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
      //  Debug.Log("Top:" + shipTop + "Bottom:" + shipBottom + "Left:" + ShipLeft + "Right:" + ShipRight);


        if (shipX > shipY) //horizontal ship
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(ShipRight + shipTestTop.GetComponent<Renderer>().bounds.size.x, (UnityEngine.Random.Range(shipBottom, shipTop)));//  shipTestTop.transform.position = new Vector2(ShipRight+ shipTestTop.GetComponent<Renderer>().bounds.size.x, (shipTop-shipBottom/2)); //(shipTop-shipBottom/2)
            shipTestTop.transform.Rotate(0, 0, -90 * 1);

            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
              float width = renderer.bounds.size.x;
             
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2(truStartX - width, (UnityEngine.Random.Range(shipBottom, shipTop))); //   shipbehind.transform.position = new Vector2(LeftDoor.transform.position.x - width, (shipTop - shipBottom / 2));
            shipbehind.transform.Rotate(0, 0, -90 * 1);
            //new random size for tops/bottoms 7-28-19
            float herdir = UnityEngine.Random.Range(-.05f, 0.5f); //  float herdir=  UnityEngine.Random.Range(shipBottom, shipTop);
            shipbehind.transform.localScale += new Vector3(herdir, 0, 0);
            shipTestTop.transform.localScale += new Vector3(herdir, 0, 0);
        }
        else if (shipY > shipX) //vertical ship
        {
            GameObject shipTestTop = Instantiate(Resources.Load("dertypShips\\shipTop")) as GameObject;
            shipTestTop.name = "shipTop";
            shipTestTop.transform.position = new Vector2(UnityEngine.Random.Range(ShipLeft, ShipRight), shipTop + shipTestTop.GetComponent<Renderer>().bounds.size.y); //   shipTestTop.transform.position = new Vector2(Mathf.Abs((ShipRight - ShipLeft) / 2), shipTop + shipTestTop.GetComponent<Renderer>().bounds.size.y);

            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
            var renderer = LeftDoor.GetComponent<Renderer>();
            float width = renderer.bounds.size.y;
            GameObject shipbehind = Instantiate(Resources.Load("dertypShips\\shipBack")) as GameObject;
            shipbehind.name = "shipbut";
            shipbehind.transform.position = new Vector2((UnityEngine.Random.Range(ShipLeft, ShipRight)), truStartY - width);  // shipbehind.transform.position = new Vector2((ShipRight - ShipLeft / 2), LeftDoor.transform.position.y - width);

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
            shipTestTop.transform.position = new Vector2(UnityEngine.Random.Range(ShipLeft, ShipRight), shipTop + shipTestTop.GetComponent<Renderer>().bounds.size.y); // shipTestTop.transform.position = new Vector2(((ShipRight - ShipLeft) / 2), shipTop+ shipTestTop.GetComponent<Renderer>().bounds.size.y);

            GameObject LeftDoor = GameObject.Find("shipHull(1" + "," + "0)");
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

     


        //6-17-19 we want to add junk  
        //  ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
        int herder = UnityEngine.Random.Range(1, 7); //we get the count of how many random objects we want to put in

        for (int i = 0; i < herder; i++)
        {
            //zero always exists , it is where the package is
            float derptyX, derptyY;
            derptyX = UnityEngine.Random.Range(posXarr[0] - 1.75f, posXarr[shipX - 1] + 1.75f);
            derptyY = UnityEngine.Random.Range(posYarr[0] - 1.75f, posYarr[shipY - 1] + 1.75f);

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
        shipbehind44.transform.position = new Vector2(ShipRight + (width44), shipTop + (height44));

        //ship back/bottom top or if horizantal- up left
        GameObject shipbehind544 = Instantiate(Resources.Load("dertypShips\\diag")) as GameObject;
        var renderer544 = shipbehind544.GetComponent<Renderer>();
        float width544 = renderer544.bounds.size.x;
        float height544 = renderer544.bounds.size.y;
        shipbehind544.name = "dertypShips\\diagLEFT";
        shipbehind544.transform.position = new Vector2(ShipLeft - (width544), shipTop + (height544 * 1.25f));


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
        shipbehind244.transform.position = new Vector2(ShipLeft - (width244), shipBottom - (height244 * 1.25f));

        shipbehind44.transform.rotation = Quaternion.Euler(new Vector3(0f, 180.0f, 0.0f));

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














    }





    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();



    void interiorShip(float moveX, float moveY, float width4)
    {

        Sprite pauseSprite = Resources.Load<Sprite>("interhull_faded(256x64)");


        GameObject dershi = Instantiate(Resources.Load("dertypShips\\interhullB")) as GameObject;
        objResourceNameHold fudg = dershi.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
        fudg.objName = "dertypShips\\interhullB";
        dershi.name = "interiorWall(" + moveX + "," + moveY + ")";
        dershi.transform.position = new Vector2((moveX), (moveY - width4 / 2));
   //     Debug.Log("Wiedth is " + width4);




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


}
