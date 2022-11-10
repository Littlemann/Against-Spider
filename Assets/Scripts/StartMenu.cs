using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
  public void StartButton()
  {
    SceneManager.LoadScene("Level1" , LoadSceneMode.Single);
  }
}
