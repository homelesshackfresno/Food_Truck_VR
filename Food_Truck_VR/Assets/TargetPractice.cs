using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public Transform[] spawnpoints;

    public GameObject target;

    private GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        if (currentTarget != null)
            currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTarget == null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        currentTarget = Instantiate<GameObject>(target, spawnpoints[Random.Range(0, spawnpoints.Length - 1)]);
    }
}
