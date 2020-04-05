using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RainController : MonoBehaviour
{
    AudioSource audioSource;
    GameObject player;

    private float INIT_VOLUME;

    [Header("音を弱める場所のX座標")]
    public List<float> weekPointX = new List<float>();
    [Header("最低音量")] 
    public float MIN_VOLUME = 0.25f;
    [Header("音が弱(強)まり始める点との距離")]
    public float NEIGHBORHOOD = 7;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");

        INIT_VOLUME = audioSource.volume;
    }

    // Update is called once per frame
    void Update() 
    {
        foreach(float loc in weekPointX)
        {
            float gap = loc - player.transform.position.x;
            if (gap >= 0 && gap <= NEIGHBORHOOD)
            { 
                audioSource.volume = (float)(INIT_VOLUME - (INIT_VOLUME - MIN_VOLUME)*System.Math.Sin(1-gap/NEIGHBORHOOD));
            }

            gap = player.transform.position.x - loc;
            if (gap >= 0 && gap <= NEIGHBORHOOD)
            {
                audioSource.volume = (float)(INIT_VOLUME - (INIT_VOLUME - MIN_VOLUME) * System.Math.Sin(1 - gap / NEIGHBORHOOD));
            }
        }

       // foreach(float loc in strongPointX)
    }

  
}
