using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spin : MonoBehaviour
{

    public spinAxis axis;
    public float rotationSpeed;
    public bool enableMovement;
    public float xBorder;
    private Vector3 pos1,pos2;


    public enum spinAxis
    {

        x,
        y,
        z

    }

    // Start is called before the first frame update
    void Start()
    {

        pos1 = new Vector3(xBorder,transform.position.y,transform.position.z);
        pos2 = new Vector3(-xBorder, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        switch (axis)
        {
            
            case spinAxis.x:
                transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                break;

            case spinAxis.y:
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                break;

            case spinAxis.z:
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                break;

        }

        if (enableMovement)
        {

            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * 0.25f, 1.0f));

        }


    }
}
