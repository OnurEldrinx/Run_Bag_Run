using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public float timeLeft;
    public float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        
        Application.targetFrameRate = 60;
        timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.Instance.isLevelStarted)
        {

            timeLeft -= Time.deltaTime;

        }

        if (timeLeft < 0)
        {
            //GameOver();
            Debug.Log("Game Over");
        }

    }
}
