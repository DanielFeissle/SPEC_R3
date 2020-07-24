using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolTurdCoolerPlacer : MonoBehaviour {
    //7-21-20 
    //this is a  special modified version of the  auto scenes script to create an array of coolers!

	// Use this for initialization
	void Start () {
        bossLoad = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    float[] posXarr = new float[3];
    float[] posYarr = new float[3];

    bool bossLoad = false;

    public void PlaceCoolers()
    {
        bossLoad = false;
        float startX = -4;
        float startY = -2.5f;
        float moveX = startX;
        float moveY = startY;

        int shipX = 2;
        int shipY = 2;
        int stupY = 1;
        int stupX = 1;
        float shipTop, shipBottom, ShipLeft, ShipRight;
        shipTop = 0;
        ShipRight = 0;
        shipBottom = shipY;
        ShipLeft = shipX;
        string loadObj = "boss\\regCool";
        for (int x = 0; x < shipX; x++)
        {
             loadObj = "boss\\regCool";
        
            stupY = 0;
            GameObject shipTest = Instantiate(Resources.Load(loadObj)) as GameObject;
            objResourceNameHold fudg = shipTest.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
            fudg.objName = "dertypShips\\genericBack";
            shipTest.name = "genericBack(" + stupX + "," + stupY + ")";
            shipTest.transform.position = new Vector2(moveX, moveY);
            posXarr[x] = moveX;
            posYarr[stupY] = moveY;

            var renderer4 = shipTest.GetComponent<Renderer>();
            float width4 = renderer4.bounds.size.x;


            GameObject fud2 = Instantiate(Resources.Load(loadObj)) as GameObject;
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
                    GameObject fud3 = Instantiate(Resources.Load(loadObj)) as GameObject;
                    fud3.name = "shipHull(" + stupX + "," + stupY + "2)";
                    fud3.transform.position = new Vector2((moveX - width2 / 2), moveY);

                }
            }
            else
            {
                fud2.transform.position = new Vector2((moveX - width2 / 2), moveY);
            }

            shipTest.transform.parent = fud2.transform; //how do I put a parent with a child prefab, this is how!

            //  moveY = shipTest.GetComponent<Renderer>().bounds.size.y + moveY;
            Debug.Log("Your MOVE" + shipTest.GetComponent<Renderer>().bounds.size.x);


            for (int y = 0; y < shipY; y++)
            {

                if ((UnityEngine.Random.Range(0, 100) < 50 && bossLoad == false)|| (y==shipY-1 &&bossLoad==false))
                {
                    bossLoad = true;
                    loadObj = "boss\\notCool";
                }
                float posX = 0;
                float posY = 0;
                stupY++;
                GameObject shipTest2 = Instantiate(Resources.Load(loadObj)) as GameObject;
                shipTest2.name = "genericBack(" + stupX + "," + stupY + ")";
                shipTest2.transform.position = new Vector2(moveX, moveY);
                loadObj = "boss\\regCool";
                //we only need the size of one box, since all the shapes are uniform It won't matter as much

                posXarr[x] = moveX;
                posYarr[stupY] = moveY;

                    GameObject fud = Instantiate(Resources.Load(loadObj)) as GameObject;
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
                            GameObject fud3 = Instantiate(Resources.Load(loadObj)) as GameObject;
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

                if (y == shipY - 1) //- 1)
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
    }
}
