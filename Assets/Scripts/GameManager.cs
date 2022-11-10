using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public virtual bool IsDontDestroyOnLoad => true;
    public event System.Action OnDeath;
    public  event System.Action<int> OnDoorTriggerEnter;
    public event System.Action OnSpiderDeath;
    public event System.Action OnSpiderAttack;
    public event System.Action OnPlayerAttack;
    public event System.Action OnFrozen;
    public event System.Action OnLevel1Done;
    public event System.Action OnLevel2Start;

   
    public bool _canMove = true;
    public bool _canSpiderMove = true;
    public bool _spiderAttacking = false;
    public bool _playerAttacking = false;
    public bool _isLevel1Done = false;
    public bool _isLevel2Start =false;



 void Awake()
    {
         if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
         else if (Instance != this) 
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        if (Instance == this as GameManager)
        {
            Instance = null;
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
        _canMove = false;
        _playerAttacking = false;
    }
    public void DoorTriggerEnter(int id)
    {
        if(OnDoorTriggerEnter != null)
        {
            OnDoorTriggerEnter(id);
        }
    }

    public void SpiderDeath()
    {
        OnSpiderDeath?.Invoke();
        _canSpiderMove = false;
        _spiderAttacking = false;
    }
    public void SpiderAttack()
    {
        OnSpiderAttack?.Invoke();
        _spiderAttacking = true;
    }
    public void PlayerAttack()
    {
        OnPlayerAttack?.Invoke();
       _playerAttacking = true;
    }
    public void Frozen()
    {
        OnFrozen?.Invoke();
        _canSpiderMove = false;

    }
    public void Level1Done()
    {
        OnLevel1Done?.Invoke();
        _isLevel1Done = true;

    }
    public void Level2Start()
    {
        OnLevel2Start?.Invoke();
        _isLevel2Start = true;
    }
  


    
}
