using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    public bool isLevelStarted;
    public bool isLevelFailed;
    public bool isLevelSucceed;
    public int levelNo;
    // Start is called before the first frame update
    void Start()
    {


        levelNo = PlayerPrefs.GetInt("LevelNo");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
