using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    public AudioClip otherClip;
    AudioSource audioSource;
    bool wasNonStage = false;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        randoMusico();
        wasNonStage = false;
    }

    private void Awake()
    {
        //   SceneManager.LoadScene("stage_PlanetSide"); //this is the clasical escape stage, everything blowing up!
        
        if (SceneManager.GetActiveScene().name.Contains("Convention"))
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\Eric Brosius - 10 - Command 1_convention");
            audioSource.clip = otherClip;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name.Contains("Bosses"))
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\Eric Brosius - 11 - Command 2_boss");
            audioSource.clip = otherClip;
            audioSource.Play();
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("OH HI THERE");
        if (SceneManager.GetActiveScene().name.Contains("Convention"))
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\Eric Brosius - 10 - Command 1_convention");
            audioSource.clip = otherClip;
            audioSource.Play();
            wasNonStage = true;
        }
        else if (SceneManager.GetActiveScene().name.Contains("Bosses"))
        {
            wasNonStage = true;
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\Eric Brosius - 11 - Command 2_boss");
            audioSource.clip = otherClip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update () {
        
        if (SceneManager.GetActiveScene().name.Contains("stage") && !SceneManager.GetActiveScene().name.Contains("Convention") && !SceneManager.GetActiveScene().name.Contains("Bosses"))
        {
            try
            {
               // Debug.Log("The total time is:" + audioSource.clip.length);
              //  Debug.Log("The cur time is:" + audioSource.time);
                if (!audioSource.isPlaying || wasNonStage==true)
                {
                    // audioSource.Play();
                    //  if (audioSource.time-5.0f >= audioSource.clip.length)
                    if (audioSource.time ==0 || wasNonStage == true)
                    {
                        wasNonStage = false; //this should let the regular music play after the convention stage
                        randoMusico();
                        audioSource.clip = otherClip;
                        audioSource.Play();
                    }



                }
            }
            catch
            {
              //  otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08101");
                audioSource.clip = otherClip;
                audioSource.Play();
            }
           
        }

        
    }

    void randoMusico()
    {
        otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08201");
        int randMusic = UnityEngine.Random.Range(1, 7);
        if (randMusic == 1)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08201");
        }
        else if (randMusic == 2)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08202");
        }
        else if (randMusic == 3)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08203");
        }
        else if (randMusic == 4)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\15 Alien Corridors2");
        }
        else if (randMusic == 5)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\leela");
        }
        else if (randMusic == 6)
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\chomber");
        }
        else
        {
            otherClip = Resources.Load<AudioClip>("_FX\\BMX\\08101");
        }
 
    }
}
