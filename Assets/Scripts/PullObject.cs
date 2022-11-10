using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] float _angularVelocity;
    [SerializeField] private Rigidbody _gearRb;
    
    private bool _canTurn;
    static public bool _turning;
    

    private void Start() 
    {
        _gearRb = GetComponent<Rigidbody>();
      
        _canTurn = false;
       
    }
   

    private void Update() 
    {
        Pull();
      
    }
   private void Pull()
   {
        if( Input.GetKey("e") && _canTurn)
        {
            _gearRb.angularVelocity = new Vector3(0f ,0f , _angularVelocity);
            GameManager.Instance.DoorTriggerEnter(id);
            _turning= true;
            StartCoroutine(TurningOff());
             
        }
        else
        {
            _gearRb.angularVelocity = new Vector3(0f , 0f , 0f);
        }
      
   }
   private void OnTriggerEnter(Collider other) 
   {    
    if(other.CompareTag("Player"))
    {
        _canTurn = true;
        StartCoroutine(TurningOff());
    }
    
   }
   IEnumerator TurningOff()
   {
    yield return new WaitForSeconds(5f);
    _turning = false;
    _canTurn = false;
   }
}
