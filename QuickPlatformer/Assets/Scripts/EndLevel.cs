using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public GameObject endGameObject;

    void Start()
    {
        endGameObject = GameObject.FindGameObjectWithTag("EndGame");
        endGameObject.SetActive(false);
    }

    [SerializeField] float LevelLoadDelay = .5f;

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(LoadNextLevel());
        if(SceneManager.GetActiveScene().name == "Level2") 
        {
            Time.timeScale = 0;
            endGameObject.SetActive(true);
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
