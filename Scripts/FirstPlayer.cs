using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private Rigidbody rb;
    [SerializeField]bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        //GetComponent<Renderer>().material = playerManager.collectedObjMat;

       
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            Grounded();
        }
    }
    private void OnCollisionExit (Collision other)
    {
        if (other.gameObject.CompareTag("Ground") )
        {
            NotGrounded();
        }
    }
    void Grounded() {
        isGrounded=true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rb.useGravity=false;
        rb.constraints=RigidbodyConstraints.FreezeAll;

        Destroy(this,1);
    }
    void NotGrounded()
    {
        isGrounded = false;
        playerManager.playerState = PlayerManager.PlayerState.Stop;
        rb.useGravity = true;

        Destroy(this, 1);
    }
}
