using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one Round manager in scene!");
        }
        else
        {
            instance = this;
        }
    }


    private int peopleFed;
    private float elapseTime;
    public float roundTime = 120f;

    private bool roundInProgress;
    public Text scoreText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        peopleFed = 0;
        elapseTime = roundTime;
        roundInProgress = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (elapseTime <= 0)
        {
            
        }
        else
        {
            elapseTime -= Time.deltaTime;
        }

        scoreText.text = peopleFed.ToString();
        timeText.text = ((int)elapseTime).ToString();

    }

    public void fedPerson()
    {
        if(!roundInProgress)
        {
            return;
        }
        peopleFed++;
    }
}
