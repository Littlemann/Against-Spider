using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    private Animator _charAnim;


    private void Start() 
    {
        _charAnim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        Attack();
      
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0) &&  GameManager.Instance._canMove && !this._charAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _charAnim.SetTrigger("Attack");
            GameManager.Instance.PlayerAttack();  
        }
    }
   
}
