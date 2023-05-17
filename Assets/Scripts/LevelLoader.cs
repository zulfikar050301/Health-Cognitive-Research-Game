using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    int sceneIndex, levelPassed;
    public static LevelLoader instance = null;
    GameObject levelSign, gameOverText, youWinText;

    void Start ()
    {
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);
        
        levelSign = GameObject.Find ("LevelText");
        gameOverText = GameObject.Find ("GameOverUI");
        youWinText = GameObject.Find ("WinUI");
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
        
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);
        
    }

    public void youWin()
    {
        if (sceneIndex == 5)
            Invoke ("loadMainMenu", 1f);
        else 
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
            levelSign.gameObject.SetActive (false);
            youWinText.gameObject.SetActive (true);
            Invoke ("loadNextLevel", 1f);
        }
    }

    public void youLose()
    {
        levelSign.gameObject.SetActive (false);
        gameOverText.gameObject.SetActive (true);
        Invoke ("loadMainMenu", 1f);
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene (sceneIndex + 1);
        // SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene ("Mainmenu");
        // SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }

    void Update()
    {
        
    }
}
