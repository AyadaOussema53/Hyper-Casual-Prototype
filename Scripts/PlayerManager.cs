using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Material collectedObjMat;
    public PlayerState playerState;
    public LevelState levelState;

    public Transform partcilePrefab;

    public List<GameObject> collidedList;

    public GameObject Player;
    public Transform collectedPoolTransform;
    public Animator _animator;
    public int Size;
    float PosX;
    public float acceleration = 0.1f;
    public float deceleration = 0.1f;
    public Text TextUI;
    public GameObject FinishedUI;
    int PosXHash;

   
    void Start()
    {
        
        _animator = Player.GetComponent<Animator>();
        PosXHash = Animator.StringToHash("PosX");
        FinishedUI.SetActive(false);
        _animator.SetBool("isFinish", false);
        _animator.SetBool("isGoodFinished", false);


    }
    void Update()
    {
       
        #region Animation ......
            Size = collidedList.Count;
        TextUI.text = "Score \n" + Size;
        if (Size >= 5 && PosX < 1.0f)
        {
            PosX += Time.deltaTime * acceleration;
        }
        if (Size >= 5 && PosX > 0.0f )
        {
            PosX += Time.deltaTime * deceleration;
        }
        if (PosX < 0.0f)
        {
            PosX = 0.0f;
        }
        if (PosX > 1.0f)
        {
            PosX = 1.0f;
        }
        _animator.SetFloat(PosXHash, PosX);
        #endregion
    }
    public enum PlayerState
    {
        Stop,
        Move
    }
    public enum LevelState 
    {
        NotFinished,
        Finished
    }

    public void CallMakeSphere () {
        foreach (GameObject obj in collidedList) {
            obj.GetComponent<CollectedObjController>().MakeSphere();
        }
        {
            
        }
    }
   
}
