using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   public void StartGame()
   {
        SceneManager.LoadScene("Game");  
   }

   public void QuitGame()
    {
        Application.Quit();
        print("Game cloased");
    }
}
