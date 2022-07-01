using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public OBSTACLE_TYPES type;
    public GameObject moltenMetal;
    public ParticleSystem explosion;
    public enum OBSTACLE_TYPES
    {

        puncher,
        fixedObstacle,
        fireMachine


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
