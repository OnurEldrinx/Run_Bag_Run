using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIComponentManager : Singleton<UIComponentManager>
{
    public TextMeshProUGUI tapToPlayText;
    public GameObject ItemsIcons;
    public Image collectable1Icon; //collectable type 1
    public Image collectable2Icon; // collectable type 2
    public Image collectable3Icon; // collectable type 3
    public Image collectable1Tick; 
    public Image collectable2Tick;
    public Image collectable3Tick;
    public GameObject collectable1Counter;
    public GameObject collectable2Counter;
    public GameObject collectable3Counter;
    public Image timeBarFillImg;

    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {

        timeBarFillImg.fillAmount = GameManager.Instance.timeLeft / GameManager.Instance.levelTime;

    }
}
