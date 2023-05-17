using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public Text TextTimer;
    public float Waktu = 100;

    public bool GameAktif = true;

    public GameObject WinUI;

    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") +":"+ Detik.ToString("00");
    }

    float s;

    private void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if(s >= 1)
            {
                Waktu--;
                s = 0;
                Time.timeScale = 1f;
                WinUI.SetActive(false);
            }
        }

        if (GameAktif && Waktu <= 0)
        {
            LevelLoader.instance.youWin();
            Debug.Log("Game Menang");
            // WinUI.SetActive(true);
            GameAktif = false;
            // Time.timeScale = 0f;

        }
        SetText();

    
    }
}
