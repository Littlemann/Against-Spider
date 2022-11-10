using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
  [SerializeField] int id;
  private Rigidbody _doorRb;

  private void Start() 
  {
    _doorRb = GetComponent<Rigidbody>();
  }
  private void OnEnable() 
  {
    GameManager.Instance.OnDoorTriggerEnter += Fall;
  }

  private void Fall(int id)
  {
    if( id== this.id)
    {
      StartCoroutine(WaitForFall());
  }
    }
        

  IEnumerator WaitForFall()
  {
    yield return new WaitForSeconds(3f);
    _doorRb.isKinematic = false;
  }
}
