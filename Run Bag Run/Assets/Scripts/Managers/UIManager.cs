using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update

    public GameObject waitUI;
    public GameObject inGameUI;
    public GameObject winUI;
    public GameObject failUI;
    public GameObject timeFailUI;
    public GameObject fireFailUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenUI(GameObject uý)
    {

        yield return new WaitForSeconds(3);
        uý.SetActive(true);

    }
}
