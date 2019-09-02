using UnityEngine;
using System.Collections;

/**
 * This class attempts to force VERT- Field of view scaling.
 * By default, Unity uses the HOR+ technique.
 * 
 * http://en.wikipedia.org/wiki/Field_of_view_in_video_games#Scaling_methods
 */

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class VertMinusCameraFOV : MonoBehaviour
{

    //public float designTimeVerticalFieldOfView = 60;
    //public int designTimeWidth = 1920; // default screen width
    //public int designTimeHeight = 1080; // default screen height

    //private float hFOVInRads;

    //private int prevWidth;
   // private int prevHeight;
    public float targetRatio = 1920f / 1080f; //The aspect ratio you did for the game.

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.aspect = targetRatio;
/*
        prevWidth = designTimeWidth;
        prevHeight = designTimeHeight;

        float aspectRatio = (float)designTimeWidth / (float)designTimeHeight;
        float vFOVInRads = designTimeVerticalFieldOfView * Mathf.Deg2Rad;
        hFOVInRads = 2f * Mathf.Atan(Mathf.Tan(vFOVInRads / 2f) * aspectRatio);
        */
    }

    void Update()
    {
        /*
        if (Screen.width != prevWidth || Screen.height != prevHeight)
        { // capture screen ratio changes

            float aspectRatio = (float)Screen.width / (float)Screen.height;

            float vFOVInRads = 2f * Mathf.Atan(Mathf.Tan(hFOVInRads / 2f) / aspectRatio);

            Debug.Log("Screen resolution change. Recomputing aspect ratio (" + aspectRatio + ") and field of view (" + vFOVInRads * Mathf.Rad2Deg + ")");

            foreach (Camera cam in GameObject.FindObjectsOfType(typeof(Camera)))
            {
                cam.fieldOfView = vFOVInRads * Mathf.Rad2Deg;
            }
        }
        */
    }

}