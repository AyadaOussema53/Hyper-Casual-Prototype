using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movementSpeed;
    [SerializeField] float controlSpeed;
    //Touch Settings
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;



    void Update()
    {
        GetInput();
        if (playerManager.levelState == PlayerManager.LevelState.Finished)
        {
            playerManager.playerState = PlayerManager.PlayerState.Stop;
            playerManager.FinishedUI.SetActive(true);
            if (playerManager.collidedList.Count < 10)
                playerManager._animator.SetBool("isFinish", true);
            if (playerManager.collidedList.Count > 10)
                playerManager._animator.SetBool("isGoodFinished", true);
        }

    }

    private void FixedUpdate() {
       
            if (playerManager.playerState == PlayerManager.PlayerState.Move)
            {
                transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            }
            if (isTouching)
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            }

            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
        
    }

    void GetInput() {
        if(Input.GetMouseButton(0)) {
            isTouching=true;
        }
        else {
            isTouching=false;
        }
    }
}
