using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
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
        if (currentTarget == null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 pos = spawnpoints[Random.Range(0, spawnpoints.Length - 1)].position;
        Quaternion rot = Quaternion.identity;
        currentTarget = Instantiate<GameObject>(target, pos, rot);
    }
}
