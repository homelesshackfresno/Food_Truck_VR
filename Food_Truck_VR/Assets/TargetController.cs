using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Vector3[] paths;
    public float moveSpeed = 2.0f;
    private Vector3 nextLocation;

    public int currentPath = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreatePath();
        nextLocation = paths[currentPath];
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position != nextLocation)
        {
            Move();
        }

       if (transform.position == nextLocation && currentPath < paths.Length)
        {
            currentPath++;
            nextLocation = paths[currentPath];
        }

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, paths[currentPath], moveSpeed);
    }

    void CreatePath()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomPath = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0f);
            Vector3 pos = transform.position;
            paths[i] = randomPath + pos;
        }
    }
}
