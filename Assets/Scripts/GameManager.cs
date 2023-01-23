using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip bgMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip startTimerSound;

    [Header("Timer")]
    public Text timerText;
    public float timerDisplay;
    public float startingTime;
    private bool timerGoing;
    private float currentTime;

    [Header("Game Objects")]
    public GameObject polarPlayer;
    private PolarController polarController;
    public GameObject restartButton;
    public Text endText;
    public ParticleSystem confetti;

    private bool touchedFinishLine;



    // Start is called before the first frame update
    void Start()
    {
        polarController = polarPlayer.GetComponent<PolarController>();
        audioSource.GetComponent<AudioSource>();
        TimerStart();
        audioSource.loop = true;
        audioSource.volume = 0.75f;
        audioSource.clip = bgMusic;
        audioSource.Play();
        confetti.Stop();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                displayTimer(currentTime);
                if (touchedFinishLine)
                {
                    winFunction();
                }
            }
            else
            {
                loseFunction();
            }
        }

    }

    void TimerStart()
    {
        timerText.gameObject.SetActive(false);
        timerGoing = false;
        timerDisplay = -1.0f;
        timerGoing = true;
        timerText.gameObject.SetActive(true);
        timerText.text = "Time: " + startingTime.ToString();
        currentTime = startingTime;
        audioSource.clip = startTimerSound;
        audioSource.PlayOneShot(startTimerSound);
        Debug.Log("Timer Started");
    }

    public void EndTimer()
    {
        currentTime = 0;
        timerGoing = false;
        Debug.Log("Timer Ended");
    }

    void displayTimer(float time)
    {
        Debug.Log("New to this");
        timerDisplay += 1;
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void loseFunction()
    {
        polarPlayer.GetComponent<Rigidbody2D>().simulated = false;
        polarPlayer.GetComponent<SpriteRenderer>().enabled = false;
        EndTimer();
        audioSource.PlayOneShot(loseMusic);
        endText.text = "You lose!";
        endText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        EndGameTimer();
    }

    public void winFunction()
    {
        EndTimer();
        polarPlayer.GetComponent<Rigidbody2D>().simulated = false;
        polarPlayer.GetComponent<SpriteRenderer>().enabled = false;
        audioSource.PlayOneShot(winMusic);
        endText.text = "You win!";
        endText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        confetti.Play();
        EndGameTimer();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void EndGameTimer()
    {
        //float endingTimer = 0f;
        //float startingTime = 2.0f;

    }
}
