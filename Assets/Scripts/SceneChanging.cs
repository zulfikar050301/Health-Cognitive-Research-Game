using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanging : MonoBehaviour
{
    // [SerializeField] RectTransform fader;

    // private void Start() {
    //     // fader.gameObject.SetActive(true);

    //     // LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
    //     // LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete (() => {
    //     //     fader.gameObject.SetActive (false);
    //     // });
    // }
    public void Gameplay()
    {
        // fader.gameObject.SetActive(true);
        // LeanTween.scale (fader, Vector3.zero, 0f);
        // LeanTween.scale (fader, new Vector3 (1, 1, 1), 0.5f).setOnComplete (() => {
            // SceneManager.LoadScene("Tetris");
            // SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        // });
        // yield return new WaitForSeconds(transitionTime);
    }

    public void Exit()
    {
        Application.Quit();
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }   

    public void mainmenu()
    {
        // fader.gameObject.SetActive(true);
        // LeanTween.scale (fader, Vector3.zero, 0f);
        // LeanTween.scale (fader, new Vector3 (1, 1, 1), 0.5f).setOnComplete (() => {
            SceneManager.LoadScene("Mainmenu");
            // SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        // });
    }

    public void LevelMenu()
    {
        // fader.gameObject.SetActive(true);
        // LeanTween.scale (fader, Vector3.zero, 0f);
        // LeanTween.scale (fader, new Vector3 (1, 1, 1), 0.5f).setOnComplete (() => {
            SceneManager.LoadScene("Level");
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        // });
    }

    public void Memory()
    {
            SceneManager.LoadScene("Puzzle");
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }

    public void Solve()
    {
            SceneManager.LoadScene("Question");
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
    }
    public void Settings()
    {
        // fader.gameObject.SetActive(true);
        // LeanTween.scale (fader, Vector3.zero, 0f);
        // LeanTween.scale (fader, new Vector3 (1, 1, 1), 0.5f).setOnComplete (() => {
            SceneManager.LoadScene("Settings");
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        // });
    }

    public void jajal()
    {
        SceneManager.LoadScene("SampleFlip");
    }
}
