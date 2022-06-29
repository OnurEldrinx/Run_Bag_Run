using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{

    public CollectableType type;
    private Vector3 initialPos;
    public float waitForJumpSeconds;
    // Start is called before the first frame update
    void Start()
    {

        initialPos = transform.position;


    }

    // Update is called once per frame
    void Update()
    {


    }

    public enum CollectableType
    {
        
        Eraser,
        Pencil,
        Book,
        

    }
    
}
