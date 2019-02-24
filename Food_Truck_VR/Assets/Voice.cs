using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioClip hey;
    public AudioClip[] hurt;
    public AudioSource audio;
    public float delay = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        hurt = new AudioClip[3];
        audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        CallOut();
        delay -= Time.deltaTime;
    }

    void CallOut()
    {
        if (delay <= 0)
        {
            Debug.Log("HEY!");
            AudioSource.PlayClipAtPoint(hey, this.transform.position);
            //audio.PlayOneShot(hey, 0.5f);
            delay = 2.2f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        audio.PlayOneShot(hurt[Random.Range(0, 2)]);
    }
}
