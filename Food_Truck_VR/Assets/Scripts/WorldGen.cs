using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject GO1;
    public GameObject GO2;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GO1, new Vector3(0, 0, 16), Quaternion.identity);
        Instantiate(GO2, new Vector3(0, 0, 48), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float TimeDelay = 32f / 16f;
        timeElapsed = timeElapsed + Time.deltaTime;
        

        if (timeElapsed >= TimeDelay)
        {
            timeElapsed = 0f;
            Instantiate(GO1, new Vector3(0, 0, 48), Quaternion.identity);
        }

    }
}
