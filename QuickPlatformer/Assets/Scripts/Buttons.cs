using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HideUI()
    {
        GameObject.Find("UI Canvas").SetActive(false);
    }

}
