using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    public AudioSource Lagu1, Lagu2, Touch;

    public Slider volume_music, volume_button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Touch.Play();
        Touch.volume = volume_button.value;

        if(gameObject.name == "ButtonSound1")
        {
            Lagu1.Play();
            Lagu2.Stop();
            Lagu1.volume = volume_music.value;
        }
        else
        {
            Lagu1.Stop();
            Lagu2.Play();
            Lagu2.volume = volume_music.value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
