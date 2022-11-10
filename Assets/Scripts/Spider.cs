using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
  [SerializeField] GameObject _player;

  [SerializeField] float _distance;

  [SerializeField] NavMeshAgent _agent; 

   private Animator _spiderAnim;

   private void Start() 
  {
      _spiderAnim = GetComponent<Animator>();
     
  }
  private void Update() 
  {
    if(GameManager.Instance._canSpiderMove)
    {
       SpiderAttack();
    }
    if(!GameManager.Instance._canSpiderMove)
    {
      _agent.speed = 0f;
      _spiderAnim.SetBool("isWalkingS" ,false); 
    } 
  }
 
 

  private void SpiderAttack()
  {
     _distance = Vector3.Distance(_player.transform.position, this.transform.position);


     if(_distance <= 75 && GameManager.Instance._canSpiderMove )
     {
        _agent.SetDestination(_player.transform.position);
        _spiderAnim.SetBool("isWalkingS" ,true);
         _agent.speed = 20;
     }
      if(_distance > 90 )
     {
        _spiderAnim.SetBool("isWalkingS" ,false); 
     }
      if(_distance < 25 )
     {
        _spiderAnim.SetBool("isAttackingS" , true);
        GameManager.Instance.SpiderAttack(); 
     }    
     if(_distance > 25)
     {
        _spiderAnim.SetBool("isAttackingS" , false);
        _agent.speed = 20;
       
     }
  }


  
}
