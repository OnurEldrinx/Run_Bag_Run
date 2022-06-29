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
            transform.parent.DOShakeScale(1.5f, 0.75f).OnComplete(() => resetBagScale());
            
            switch (other.gameObject.GetComponent<Collectable>().type)
            {
                
                case Collectable.CollectableType.Eraser:

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
                playerHolder.transform.GetChild(0).DOShakeScale(1.5f,0.75f).OnComplete(() => resetBagScale());

            }

        }else if (other.tag.Equals("Finish"))
        {

            playerHolder.GetComponent<PlayerMovement>().forwardSpeed = 0;
            playerHolder.GetComponent<PlayerMovement>().slideSpeed = 0;

            UIManager.Instance.inGameUI.SetActive(false);

            Finish.Instance.finishCam.SetActive(true);

            playerHolder.transform.DOJump(Finish.Instance.bagPosition.position, 3, 1, 1.5f).OnComplete(() => {


                

                if (!LevelManager.Instance.isLevelFailed && CollectionManager.Instance.isAllCollected)
                {

                    LevelManager.Instance.isLevelSucceed = true;
                    Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Dance", true);

                }
                else
                {

                    LevelManager.Instance.isLevelFailed = true;
                    Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Fail", true);

                }




            });

            /*
            if (!LevelManager.Instance.isLevelFailed && CollectionManager.Instance.isAllCollected)
            {

                LevelManager.Instance.isLevelSucceed = true;
                Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Dance", true);

            }
            else
            {

                LevelManager.Instance.isLevelFailed = true;
                Finish.Instance.finishChar.GetComponent<Animator>().SetBool("Fail", true);

            }*/



        }
    }
}