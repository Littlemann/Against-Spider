using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _turningSound;

    private bool _isPlayed =false;
    void Update()
    {
        PlayTurningSound();
    }
    private void PlayTurningSound()
    {
        
        if(PullObject._turning && !_isPlayed)
        {
            _audioSource.PlayOneShot(_turningSound , 1f);
            _isPlayed = true;
             StartCoroutine(PlayAgain());
        }
       
    }
    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(5f);
        _isPlayed = false;
    }
   
}
