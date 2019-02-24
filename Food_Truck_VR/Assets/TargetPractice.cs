using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public Transform[] spawnpoints;

    public GameObject target;

    private GameObject currentTarget = null;
    private int lastSpawnPoint = 0;

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
        int newIndex = Random.Range(0, spawnpoints.Length - 1);
        while (newIndex == lastSpawnPoint)
        {
            newIndex = (newIndex + 1) % spawnpoints.Length;
        }
        lastSpawnPoint = newIndex;

        Vector3 pos = spawnpoints[newIndex].position;
        Quaternion rot = Quaternion.identity;

        currentTarget = Instantiate<GameObject>(target, pos, rot);
    }
}
