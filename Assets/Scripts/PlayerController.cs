using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{   
    private float _inputhorizontal;
   
    private float _inputvertical;
   
    private Rigidbody _charRb;
    
    [SerializeField] private float _speed;

    [SerializeField] Animator myAnimator;
    
   
    private void Start() 
    {
        _charRb = GetComponent<Rigidbody>();
       myAnimator = GetComponent<Animator>();
       myAnimator.SetBool("isWalking" ,false);
       
    }
    
    void Update()
    {
        if(GameManager.Instance._canMove && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Movement();
        }
      
    }

    private void Movement()
    {
        
        
        _inputhorizontal = Input.GetAxis("Horizontal");
        _inputvertical = Input.GetAxis("Vertical");

    
        Vector3 direction = new Vector3(_inputhorizontal, 0 ,_inputvertical);
        _charRb.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime); 


         if(direction != Vector3.zero)
    {
         myAnimator.SetBool("isWalking" , true);
         transform.forward = direction;
    }

    else
    {
        myAnimator.SetBool("isWalking" , false);
    }
    }
   
  
 
    
}
