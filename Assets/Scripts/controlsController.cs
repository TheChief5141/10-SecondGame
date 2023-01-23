using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsController : MonoBehaviour
{
    public float startingTimer;
    private float currentTime;
    private bool timerGoing = false;

    public AudioSource audioSource;
    public AudioClip startMusic;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTimer;
        timerGoing = true;

        audioSource.PlayOneShot(startMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
