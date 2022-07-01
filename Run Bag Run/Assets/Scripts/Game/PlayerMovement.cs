using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private float? lastMousePoint = null;
    public float RestirictionX = 3.5f;
    public GameObject PlayerHolder;
    private Vector3 oldPos;
    private Quaternion oldRot;
    private bool mouseControl;
    //private PlayerManager _playerManager;

    public bool PlayerRotateEnabled;
    public float RotatationDegree;
    public float RotationSpeed;
    private float _oldPosition;

    public float forwardSpeed;
    public float slideSpeed;
    private void Awake()
    {
        //_playerManager = PlayerManager.Instance;
    }

    private void LateUpdate()
    {

        _oldPosition = PlayerHolder.transform.localPosition.x;
    }

    private void Update()
    {

        if(LevelManager.Instance.isLevelFailed || LevelManager.Instance.isLevelSucceed)
        {

            forwardSpeed = 0;
            slideSpeed = 0;

        }


        if (Input.GetMouseButtonDown(0) && !LevelManager.Instance.isLevelStarted)
        {

            LevelManager.Instance.isLevelStarted = true;
            UIManager.Instance.waitUI.SetActive(false);

        }


        if (LevelManager.Instance.isLevelStarted)
        {


            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

            if (!mouseControl)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lastMousePoint = Input.mousePosition.x;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    lastMousePoint = null;
                }
                if (lastMousePoint != null)
                {
                    float difference = Input.mousePosition.x - lastMousePoint.Value;
                    PlayerHolder.transform.position = new Vector3(PlayerHolder.transform.position.x + (difference / 188) * Time.deltaTime * slideSpeed, PlayerHolder.transform.position.y, PlayerHolder.transform.position.z);
                    lastMousePoint = Input.mousePosition.x;
                }

                float xPos = Mathf.Clamp(PlayerHolder.transform.position.x, -RestirictionX, RestirictionX);
                PlayerHolder.transform.position = new Vector3(xPos, PlayerHolder.transform.position.y, PlayerHolder.transform.position.z);
                Vector3 movement = oldRot * (PlayerHolder.transform.position - oldPos);

                if (PlayerRotateEnabled && PlayerHolder != null)
                {
                    if (PlayerHolder.transform.localPosition.x > _oldPosition)
                    {
                        PlayerHolder.transform.DORotate(new Vector3(0f, -RotatationDegree, 0f), RotationSpeed);
                    }

                    else if (PlayerHolder.transform.localPosition.x < _oldPosition)
                    {
                        PlayerHolder.transform.DORotate(new Vector3(0f, RotatationDegree, 0f), RotationSpeed);
                    }
                    else
                    {
                        PlayerHolder.transform.DORotate(new Vector3(0f, 0f, 0f), RotationSpeed);
                    }
                    _oldPosition = PlayerHolder.transform.localPosition.x;
                }

            }
        }
    }
}

