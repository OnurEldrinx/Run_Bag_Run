using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : Singleton<CollectionManager>
{

    public List<GameObject> collectedType1s;
    public List<GameObject> collectedType2s;
    public List<GameObject> collectedType3s;

    private int collectable1Target;
    private int collectable2Target;
    private int collectable3Target;

    private int collectable1TargetInitial;
    private int collectable2TargetInitial;
    private int collectable3TargetInitial;

    private int extra1s;
    private int extra2s;
    private int extra3s;

    public int Collectable1Target { get => collectable1Target; set => collectable1Target = value; }
    public int Collectable2Target { get => collectable2Target; set => collectable2Target = value; }
    public int Collectable3Target { get => collectable3Target; set => collectable3Target = value; }


    // Start is called before the first frame update
    void Start()
    {

        collectedType1s = new List<GameObject>();
        collectedType2s = new List<GameObject>();
        collectedType3s = new List<GameObject>();

        Collectable1Target = Random.Range(2, 5);
        Collectable2Target = Random.Range(2, 5);
        Collectable3Target = Random.Range(2, 5);

        collectable1TargetInitial = Collectable1Target;
        collectable2TargetInitial = Collectable2Target;
        collectable3TargetInitial = Collectable3Target;


        UIComponentManager.Instance.collectable1Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable1Target);
        UIComponentManager.Instance.collectable2Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable2Target);
        UIComponentManager.Instance.collectable3Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable3Target);


    }

    // Update is called once per frame
    void Update()
    {

        if (Collectable1Target > 0)
        {
            UIComponentManager.Instance.collectable1Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable1Target);
        }

        if (Collectable2Target > 0)
        {
            UIComponentManager.Instance.collectable2Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable2Target);
        }

        if (Collectable3Target > 0)
        {
            UIComponentManager.Instance.collectable3Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("x" + Collectable3Target);
        }


        if (collectedType1s.Count > collectable1TargetInitial)
        {

            if (!UIComponentManager.Instance.collectable1Counter.activeInHierarchy)
            {

                UIComponentManager.Instance.collectable1Counter.SetActive(true);

            }

            extra1s = collectedType1s.Count - collectable1TargetInitial;

            UIComponentManager.Instance.collectable1Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("+" + (extra1s));
            UIComponentManager.Instance.collectable1Counter.GetComponent<Image>().color = Color.red;
        }

        if (collectedType2s.Count > collectable2TargetInitial)
        {

            if (!UIComponentManager.Instance.collectable2Counter.activeInHierarchy)
            {

                UIComponentManager.Instance.collectable2Counter.SetActive(true);

            }

            extra2s = collectedType2s.Count - collectable2TargetInitial;

            UIComponentManager.Instance.collectable2Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("+" + (extra2s));
            UIComponentManager.Instance.collectable2Counter.GetComponent<Image>().color = Color.red;

        }

        if (collectedType3s.Count > collectable3TargetInitial)
        {

            if (!UIComponentManager.Instance.collectable3Counter.activeInHierarchy) {

                UIComponentManager.Instance.collectable3Counter.SetActive(true);

            }

            extra3s = collectedType3s.Count - collectable3TargetInitial;

            UIComponentManager.Instance.collectable3Counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("+" + (extra3s));
            UIComponentManager.Instance.collectable3Counter.GetComponent<Image>().color = Color.red;

        }



    }
}
