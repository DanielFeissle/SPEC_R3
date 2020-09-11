using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PathFollower : MonoBehaviour {
    //9-9-20this is a rough line follow script
    // various location/ideas
    //https://stackoverflow.com/questions/56948496/how-to-make-game-objects-follow-a-path-in-order-in-unity-along-a-bezier-curve
    public Transform nodes;

    void Awake()
    {
        PathNode = new GameObject[nodes.childCount];
        for (int i = 0; i < nodes.childCount; i++)
        {
            PathNode[i] = nodes.GetChild(i).gameObject;
        }
    }



 

    public Transform[] path;
    //STATE MACHINES
    /*   public enum EnemyStates
       {
           ON_PATH,
           IDLE
       }
       public EnemyStates enemyState; 

       public int enemyID;
       */
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 1; path != null && i < path.Length; ++i)
        {
            Gizmos.DrawLine(PathNode[i].transform.position,PathNode[i].transform.position);
        }
        //nodes.GetChild(i).transform[i - 1].position, path[i].position
    }
    public GameObject[] PathNode;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;


    // Use this for initialization
    void Start()
    {
        MoveSpeed = 0.5f;
        Player = this.gameObject;
        //PathNode = GetComponentInChildren<>();
        CheckNode();
      //  OnDrawGizmos();
    }

    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime * MoveSpeed;

        if (Player.transform.position != CurrentPositionHolder)
        {

            Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {

            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }






}
