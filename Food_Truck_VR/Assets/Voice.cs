using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioClip hey;
    public AudioSource audio;
    public float delay = 1.8f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }

    void CallOut()
    {
        if (delay <= 0)
        {
            audio.PlayOneShot(hey, 0.5f);
        }

        delay = 1.8f;
    }
}
