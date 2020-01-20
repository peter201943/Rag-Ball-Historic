using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    // Variables
    //public GameObject RedGoal;
    //public GameObject BlueGoal;
    public int RedScore;
    public int BlueScore;
    public int WinScore = 5;
    public GameObject redscoreboard;
    public GameObject bluescoreboard;
    public GameObject Pause_redscoreboard;
    public GameObject Pause_bluescoreboard;
    public string BlueScoreText;
    public string RedScoreText;
    public Canvas RedWinScreen;
    public Canvas BlueWinScreen;
    public ParticleSystem BluePipeConfetti;
    public ParticleSystem RedPipeConfetti;
    public ParticleSystem ExitPipeConfetti;
    public GameObject audiomanager;


    // Start is called before the first frame update
    void Start()
    {
        RedScore = 00;
        BlueScore = 00;
    }

    // Update is called once per frame
    void Update()
    {
        //Red Score
        RedScoreText = RedScore.ToString();
        if (RedScore < 10) RedScoreText = "0" + RedScoreText;
        redscoreboard.GetComponent<TextMeshPro>().text = RedScoreText;
        //Pause_redscoreboard.GetComponent<TextMeshPro>().text = RedScoreText;

        //Debug.Log("=====================\n===================\n====================");

        //Blue Score
        BlueScoreText = BlueScore.ToString();
        //Debug.Log("WHERE IS THE SCORE!\n" + BlueScoreText);
        if (BlueScore < 10) BlueScoreText = "0" + BlueScoreText;
        bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;
        //Pause_bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;

        if (Input.GetKey("c") || Input.GetKey("x") || Input.GetKey("v"))
        {
            RedPipeConfetti.Play();
            BluePipeConfetti.Play();
            ExitPipeConfetti.Play();
            
        }
        if (Input.GetKeyDown("c"))
        {
            audiomanager.transform.Find("Goal_AudioSource").GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown("x"))
        {
            audiomanager.transform.Find("Goal_AudioSourceLow").GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown("v"))
        {
            audiomanager.transform.Find("Goal_AudioSourceHigh").GetComponent<AudioSource>().Play();
        }

    }

    public void AddRedScore()
    {
        RedScore += 1;
        if (RedScore >= WinScore)
        {
            RedWinScreen.enabled = true;
            RedPipeConfetti.loop = true;
            BluePipeConfetti.loop = true;
            ExitPipeConfetti.loop = true;
            RedPipeConfetti.Play();
            BluePipeConfetti.Play();
            ExitPipeConfetti.Play();
            Debug.Log("RED WINS");
        }
    }
    public void AddBlueScore()
    {
        BlueScore += 1;
        if (BlueScore >= WinScore)
        {
            BlueWinScreen.enabled = true;
            RedPipeConfetti.loop = true;
            BluePipeConfetti.loop = true;
            ExitPipeConfetti.loop = true;
            RedPipeConfetti.Play();
            BluePipeConfetti.Play();
            ExitPipeConfetti.Play();
            Debug.Log("BLUE WINS");
        }
    }


}
