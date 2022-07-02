using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{

    public float timeLeft;
    public float levelTime;

    // Start is called before the first frame update
    void Start()
    {

        UIComponentManager.Instance.levelNoText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();

        Application.targetFrameRate = 60;
        timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager.Instance.isLevelStarted && !LevelManager.Instance.isLevelFailed && !LevelManager.Instance.isLevelSucceed && !Finish.Instance.reached)
        {

            timeLeft -= Time.deltaTime;

        }

        if (timeLeft < 0)
        {
            //GameOver();
            LevelManager.Instance.isLevelFailed = true;
            UIManager.Instance.inGameUI.SetActive(false);
            UIManager.Instance.timeFailUI.SetActive(true);
            
        }

    }

    public void GameOver()
    {



    }

    public void WinState()
    {

        LevelManager.Instance.isLevelSucceed = true;
        Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Dance", true);
        StartCoroutine(UIManager.Instance.OpenUI(UIManager.Instance.winUI));

    }

    public void FailState()
    {

        LevelManager.Instance.isLevelFailed = true;
        Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Fail", true);
        StartCoroutine(UIManager.Instance.OpenUI(UIManager.Instance.failUI));


    }


    public void NextLevel()
    {

        DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RestartLevel()
    {

        DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
