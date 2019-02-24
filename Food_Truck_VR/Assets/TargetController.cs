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
        if(paths.Length == 0)
        {
            paths = new Vector3[Random.Range(1, 4)];
        }
        CreatePath();
        nextLocation = paths[currentPath];
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position != nextLocation)
        {
            //Debug.Log("Moving!");
            Move();
        }

       if ((transform.position - nextLocation).magnitude < .2f && currentPath < paths.Length)
        {
            currentPath = (currentPath + 1) % paths.Length;
            nextLocation = paths[currentPath ];
            LookAtPath();
        }

    }

    void Move()
    {
        Vector3 dir = paths[currentPath] - transform.position;
        dir.Normalize();
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    void CreatePath()
    {
        for (int i = 0; i < paths.Length; i++)
        {
            Vector3 randomPath = new Vector3(Random.Range(-2.0f, 2.0f), 0f, Random.Range(-2.0f, 2.0f));
            Vector3 pos = transform.position;
            paths[i] = randomPath + pos;
        }
    }

    void LookAtPath()
    {
        Vector3 dir = paths[currentPath] - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, moveSpeed * time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void OnCollisionEnter()
    {
        currentPath = (currentPath + 1) % paths.Length;
        nextLocation = paths[currentPath];
    }
}
