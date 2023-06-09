using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    public static AudioClip gameWinMusic;
    static AudioSource audioSrc;

    void Start()
    {
        gameWinMusic = Resources.Load<AudioClip>("winMusic");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        audioSrc.PlayOneShot(gameWinMusic);
    }
}
