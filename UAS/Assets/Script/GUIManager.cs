using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour
{
   public void OnPlay()
    {
        SceneManager.LoadScene("Main");
    }
   public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnHelp()
    {
        SceneManager.LoadScene("Help");
    }
     public void OnLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void OnEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void OnMedium()
    {
        SceneManager.LoadScene("Medium");
    }
    public void OnMulti()
    {
        SceneManager.LoadScene("Multi");
    }
     public void OnHard()
    {
        SceneManager.LoadScene("Hard");
    }
}
