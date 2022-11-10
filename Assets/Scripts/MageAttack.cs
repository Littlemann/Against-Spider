using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageAttack : MonoBehaviour
{
    
   [SerializeField] private float _speed;
   [SerializeField] Transform _firePoint;
   [SerializeField] Rigidbody _fireballPrefab;
   [SerializeField] Rigidbody _iceBallPrefab;
   [SerializeField] Slider slider;
   [SerializeField] private int _maxMana = 200;
   [SerializeField] private int _currentMana;
   [SerializeField] AudioClip _fireSpellSound;
   [SerializeField] AudioClip _iceSpellSound;
   [SerializeField] AudioSource _audioSource;
   private bool _isAvaliable = true;
   private bool _switched;
   private Animator _charAnim;
   





    private void Start() 
    {
        _charAnim = GetComponent<Animator>();
         _currentMana = _maxMana;
        SetMaxMana(_maxMana);
        
    }
     public void SetMaxMana(int _mana)
   {
     slider.maxValue = _mana;
     slider.value = _mana;
   }
    public void SetMana(int _mana)
   {
     slider.value = _mana;
   }

    private void Update()
    {
        Attack();
       SwitchSpell();
       if(_currentMana > 200)
       {
        _currentMana = _maxMana;
       }
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0) &&  GameManager.Instance._canMove &&  _currentMana >= 0 && _isAvaliable)
        {
            
            InstantiateFireBall();
                
            InstantiateIceBall();
           
            GameManager.Instance.PlayerAttack();
            LoseMana(10);
            StartCoroutine(CoolDown());
            
        }
        if(!_isAvaliable)
        {
            return;
        }
        
    }
    private void InstantiateFireBall()
    {
        if(!_switched)
        {
            var _fireSpellBall =  Instantiate(_fireballPrefab , _firePoint.position ,_firePoint.rotation );
            _fireSpellBall.AddForce(_firePoint.forward * _speed , ForceMode.Impulse);
            _audioSource.PlayOneShot(_fireSpellSound, 0.4f);
        }
          
    }

    private void InstantiateIceBall()
    {
        if(_switched)
        {
            var _iceSpellBall = Instantiate(_iceBallPrefab , _firePoint.position , _firePoint.rotation);
            _iceSpellBall.AddForce(_firePoint.forward * _speed ,ForceMode.Impulse);
           _audioSource.PlayOneShot(_iceSpellSound, 0.4f);
        }
    }
        
    private void OnTriggerEnter(Collider other) 
    {
          if(other.CompareTag("PowerUp"))
    {
        _charAnim.SetTrigger("Drink");
         other.gameObject.SetActive(false);
         GetMana(60);

    }
    }
    private void GetMana(int _mana)
   {
     
      _currentMana += _mana;
       SetMana(_currentMana);
      
   }
   private void LoseMana(int _lose)
   {
    _currentMana -= _lose;
    SetMana(_currentMana);
   }
   private void SwitchSpell()
   {
     if(Input.GetKeyDown(KeyCode.G))
     {
        _switched = true;
     }
     if(Input.GetKeyDown(KeyCode.F))
     {
        _switched = false;
     }
   }
   IEnumerator CoolDown()
   {
    _isAvaliable = false;
    yield return new WaitForSeconds(1f);
    _isAvaliable = true;
   }
  
   
}
