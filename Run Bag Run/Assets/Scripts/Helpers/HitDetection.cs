using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using DG.Tweening;

public class HitDetection : MonoBehaviour
{

    public GameObject playerHolder;
    private float speedLoss;
    private Vector3 initialScale;
    public float shakeScalePower;

    // Start is called before the first frame update
    void Start()
    {
        speedLoss = 0.5f;
        initialScale = playerHolder.transform.GetChild(0).transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    private void resetBagScale()
    {

        playerHolder.transform.GetChild(0).transform.localScale = initialScale;


    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Collectable"))
        {

            other.gameObject.SetActive(false);
            transform.parent.DOShakeScale(1.5f, shakeScalePower).OnComplete(() => resetBagScale());
            
            switch (other.gameObject.GetComponent<Collectable>().type)
            {
                
                case Collectable.CollectableType.Eraser:
                case Collectable.CollectableType.OxygenTank:
                case Collectable.CollectableType.Floatie:
                case Collectable.CollectableType.Handsaw:
                case Collectable.CollectableType.Sneakers:


                    CollectionManager.Instance.Collectable1Target--;

                    CollectionManager.Instance.collectedType1s.Add(other.gameObject);

                    if (CollectionManager.Instance.Collectable1Target == 0)
                    {

                        UIComponentManager.Instance.collectable1Tick.gameObject.SetActive(true);
                        UIComponentManager.Instance.collectable1Counter.SetActive(false);

                    }

                    if (CollectionManager.Instance.Collectable1Target < 0)
                    {

                        playerHolder.GetComponent<PlayerMovement>().forwardSpeed -= speedLoss;

                    }

                    break;

                case Collectable.CollectableType.Book:
                case Collectable.CollectableType.AstroHelmet:
                case Collectable.CollectableType.Sunblock:
                case Collectable.CollectableType.Wrench:
                case Collectable.CollectableType.Whey:


                    CollectionManager.Instance.Collectable2Target--;

                    CollectionManager.Instance.collectedType2s.Add(other.gameObject);

                    if (CollectionManager.Instance.Collectable2Target == 0)
                    {

                        UIComponentManager.Instance.collectable2Tick.gameObject.SetActive(true);
                        UIComponentManager.Instance.collectable2Counter.SetActive(false);

                    }

                    if (CollectionManager.Instance.Collectable2Target < 0)
                    {

                        playerHolder.GetComponent<PlayerMovement>().forwardSpeed -= speedLoss;

                    }

                    break;

                case Collectable.CollectableType.Pencil:
                case Collectable.CollectableType.Powercell:
                case Collectable.CollectableType.Towel:
                case Collectable.CollectableType.Hammer:
                case Collectable.CollectableType.Shaker:

                    CollectionManager.Instance.Collectable3Target--;

                    CollectionManager.Instance.collectedType3s.Add(other.gameObject);

                    if (CollectionManager.Instance.Collectable3Target == 0)
                    {

                        UIComponentManager.Instance.collectable3Tick.gameObject.SetActive(true);
                        UIComponentManager.Instance.collectable3Counter.SetActive(false);

                    }

                    if(CollectionManager.Instance.Collectable3Target < 0)
                    {

                        playerHolder.GetComponent<PlayerMovement>().forwardSpeed -= speedLoss;

                    }

                break;
                
            }

        }else if(other.tag.Equals("Obstacle"))
        {

            if (other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.puncher))
            {

                playerHolder.transform.GetChild(0).DOMoveX(-other.transform.parent.transform.position.x / 2 , 0.25f).SetEase(Ease.Flash);
                playerHolder.transform.GetChild(0).DOShakeScale(1.5f,shakeScalePower).OnComplete(() => resetBagScale());

            }else if (other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.fixedObstacle) || other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.spinner) || other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.barbedObstacle))
            {

                playerHolder.transform.DOMoveZ(playerHolder.transform.position.z - 3, 0.5f).SetEase(Ease.OutFlash);

            }else if (other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.fireMachine))
            {

                playerHolder.GetComponent<PlayerMovement>().forwardSpeed = 0;
                playerHolder.GetComponent<PlayerMovement>().slideSpeed = 0;
                playerHolder.transform.GetChild(0).gameObject.SetActive(false);
                other.GetComponent<Obstacle>().explosion.Play();
                other.GetComponent<Obstacle>().moltenMetal.SetActive(true);
                LevelManager.Instance.isLevelFailed = true;
                UIManager.Instance.inGameUI.SetActive(false);
                UIManager.Instance.fireFailUI.SetActive(true);


            }else if (other.GetComponent<Obstacle>().type.Equals(Obstacle.OBSTACLE_TYPES.movingSaw))
            {

                playerHolder.GetComponent<PlayerMovement>().forwardSpeed = 0;
                playerHolder.GetComponent<PlayerMovement>().slideSpeed = 0;
                playerHolder.transform.GetChild(0).gameObject.SetActive(false);
                other.GetComponent<Obstacle>().explosion.Play();
                LevelManager.Instance.isLevelFailed = true;
                UIManager.Instance.inGameUI.SetActive(false);
                UIManager.Instance.sawFailUI.SetActive(true);

            }

        }
        else if (other.tag.Equals("Finish"))
        {

            Finish.Instance.reached = true;

            other.GetComponent<BoxCollider>().enabled = false;

            playerHolder.GetComponent<PlayerMovement>().forwardSpeed = 0;
            playerHolder.GetComponent<PlayerMovement>().slideSpeed = 0;

            UIManager.Instance.inGameUI.SetActive(false);

            Finish.Instance.finishCam.SetActive(true);

            playerHolder.transform.GetChild(0).transform.DOJump(Finish.Instance.bagPosition.position,2,4,2f).SetEase(Ease.InOutSine).OnComplete(() => {



                if (!LevelManager.Instance.isLevelFailed && CollectionManager.Instance.isAllCollected)
                {

                    /*
                    LevelManager.Instance.isLevelSucceed = true;
                    Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Dance", true);
                    StartCoroutine(UIManager.Instance.OpenUI(UIManager.Instance.winUI));*/

                    GameManager.Instance.WinState();

                }
                else
                {
                    /*
                    LevelManager.Instance.isLevelFailed = true;
                    Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Fail", true);*/

                    GameManager.Instance.FailState();

                }




           });

            



        }
    }
}
