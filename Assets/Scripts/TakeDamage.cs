using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] Animator _charAnim;

    [SerializeField] Slider slider;

    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private int _currentHealth;

   

    private void Start() 
    {
        _currentHealth = _maxHealth;
        SetMaxHealth(_maxHealth);
    }


    private void Update()
    {
        Die();
        if(_currentHealth > 100)
        {
          _currentHealth = _maxHealth;
        }
    }
   
   public void SetMaxHealth(int _health)
   {
     slider.maxValue = _health;
     slider.value = _health;
   }
   public void SetHealth(int _health)
   {
    slider.value = _health;
   }
   private void OnTriggerEnter(Collider other) 
   {
     if( GameManager.Instance._spiderAttacking && other.CompareTag("Spider"))
     {
        _charAnim.SetTrigger("GetHit");
       
        TakeDamages(10);
        
     }
      if( GameManager.Instance._spiderAttacking && other.CompareTag("BlackSpider"))
     {
        _charAnim.SetTrigger("GetHit");
       
        TakeDamages(20);
        
     }
      if( GameManager.Instance._spiderAttacking && other.CompareTag("GreenSpider"))
     {
        _charAnim.SetTrigger("GetHit");
       
        TakeDamages(30);
        
     }
      if(other.CompareTag("PowerUp"))
    {
        _charAnim.SetTrigger("Drink");
         other.gameObject.SetActive(false);
         GetHeal(40);
        

    }
   }
   private void TakeDamages(int _damage)
   {
    _currentHealth -= _damage;
    SetHealth(_currentHealth);
   }
   private void Die()
   {
     if(_currentHealth <= 0)
     {
        _charAnim.SetBool("isDead" , true);
         _charAnim.SetBool("isWalking" , false);
         GameManager.Instance._canMove = false;
     }
   }
   private void GetHeal(int _heal)
   {
     
      _currentHealth += _heal;
       SetHealth(_currentHealth);
      
   }
   
  

   
}
