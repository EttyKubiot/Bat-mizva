using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;
   

    void Start()
    {
        gameManager.OnCorrectClick += Correct4;
        gameManager.OnWrongClick += NotCorrect4;
        audioSource.clip = sounds[2];
        audioSource.Play();
    }

    private void Correct4()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();
        StartCoroutine(StopAudio());
    }

    private void NotCorrect4()
    {
        audioSource.clip = sounds[1];
        audioSource.Play();
        StartCoroutine(StopAudio());
    }
    private IEnumerator StopAudio()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = sounds[2];
        audioSource.Play();



    }
}
