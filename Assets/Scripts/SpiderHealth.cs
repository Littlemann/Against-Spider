using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderHealth : MonoBehaviour
{
   [SerializeField] private Animator _spiderAnim;
   [SerializeField] private int  _maxHealth = 100;
   [SerializeField] private int _currentHealth;
   [SerializeField] GameObject _fakeWall;
   [SerializeField] GameObject _onFire;
   [SerializeField] GameObject[] _invisObjects;
   [SerializeField] GameObject _normalSpider;
   [SerializeField] AudioSource _audioSource;
   [SerializeField] AudioClip _freezeSound;
  
    private void Start() 
    {
        _spiderAnim =  GetComponent<Animator>();
        _currentHealth = _maxHealth;
        _fakeWall.SetActive(true);
        _onFire.SetActive(false);
        _normalSpider.SetActive(true);
        for (int i = 0; i < _invisObjects.Length; i++)
        {
          _invisObjects[i].SetActive(false);
        }
       
  
    }
   
    private  void Update() 
    {
       Death();
     
    }

  private void OnTriggerEnter(Collider other) 

  {
    if( other.CompareTag("Sword")&& GameManager.Instance._playerAttacking)
    {
       
        
        TakeDamage(50);
         GameManager.Instance._playerAttacking = false;  
         
    }
    if( other.CompareTag("Fire"))
    {
        
        other.gameObject.SetActive(false);
        _onFire.SetActive(true);
        _normalSpider.SetActive(true);
        GameManager.Instance._canSpiderMove = true;
        TakeDamage(35);
           
    }
     if( other.CompareTag("Ice"))
    {
      GameManager.Instance.Frozen();
      other.gameObject.SetActive(false);
      _normalSpider.SetActive(false);
      _onFire.SetActive(false);
      StartCoroutine(FrozenTime());
      _audioSource.PlayOneShot(_freezeSound , 0.3f);
      TakeDamage(15);
           
    }
  }

  private void TakeDamage(int _damage)
  {
    _currentHealth -= _damage;
    
  }
  private void Death()
  {
    if(_currentHealth <= 0 )
    {
        _onFire.SetActive(false);
        _spiderAnim.SetTrigger("Dead");
        GameManager.Instance.SpiderDeath();
        StartCoroutine(DestroySpider());
       
    }
    if(_currentHealth <= 0  && CompareTag("BlackSpider"))
    {
        _spiderAnim.SetTrigger("Dead");
        GameManager.Instance.SpiderDeath();
        StartCoroutine(DestroySpider());
        GameManager.Instance.Level1Done();
       for (int i = 0; i < _invisObjects.Length; i++)
        {
          _invisObjects[i].SetActive(true);
        }
        _fakeWall.SetActive(false);
        
    }
     if(_currentHealth <= 0  && CompareTag("GreenSpider"))
    {
        _spiderAnim.SetTrigger("Dead");
        GameManager.Instance.SpiderDeath();
        StartCoroutine(DestroySpider());
       for (int i = 0; i < _invisObjects.Length; i++)
        {
          _invisObjects[i].SetActive(true);
        }
        _fakeWall.SetActive(false);
        
    }
  }
  IEnumerator DestroySpider()
  {
    yield return new WaitForSeconds(3f);
    gameObject.SetActive(false);
    GameManager.Instance._canSpiderMove = true;
  }
  IEnumerator FrozenTime()
  {
    yield return new WaitForSeconds(4f);
    _normalSpider.SetActive(true);
    GameManager.Instance._canSpiderMove = true;
  }
}
