using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
  
   [SerializeField] AudioClip _bg2Sound;
   [SerializeField] AudioSource _audioSource;
   private bool _hasSongStopped = false;

  
   private void Update()
   {
   
    if(!_hasSongStopped)
    {
        ChangeBackgroundSong();
    }
   }
    private void ChangeBackgroundSong()
    {
        if(GameManager.Instance._isLevel1Done)
        {
           _audioSource.Stop();
           _hasSongStopped = true;
            _audioSource.PlayOneShot(_bg2Sound , 0.6f);
        }
         
    }
  
}
