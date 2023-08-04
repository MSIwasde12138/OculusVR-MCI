using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class moviecontroller : MonoBehaviour
{

    public Button button_play_or_pause;
    public Text text_play_or_pause;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private RawImage rawImage;
    private int faq = 0;

    // Start is called before the first frame update
    void Start()
    {

        videoPlayer = this.GetComponent<VideoPlayer>();
        audioSource = this.GetComponent<AudioSource>();
        rawImage = this.GetComponent<RawImage>();
        button_play_or_pause.onClick.AddListener(PlayorPause);

    }

    // Update is called once per frame
    void Update()
    {

        if (faq == 0)
        {

            if (videoPlayer == null)
            {

                return;

            }

        }

    }
    void PlayorPause()
    {
        if (videoPlayer.isPlaying == true)
        {
            videoPlayer.Pause();
            audioSource.Pause();
            text_play_or_pause.text = "≤•∑≈ ”∆µ";
        }
        else
        {
            videoPlayer.Play();
            audioSource.Play();
            text_play_or_pause.text = "‘›Õ£ ”∆µ";
        }
    }
}
