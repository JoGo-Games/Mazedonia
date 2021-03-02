using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public bool game_paused;
    public MovementInput player;
    public GameObject ingamemenu;
    public Animator ingameanimator;
    public GameObject winmenu;
    public GameObject pausemenu;
    public TimerController time;
    public TextMeshProUGUI scoreText;

    public float transitionTime;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Change_State(game_paused);
        }
    }

    public void Restart_Position()
    {
        player.Restart_Position();
    }

    public void Level_Finished()
    {
        Debug.Log("Finish");
        winmenu.SetActive(true);
        pausemenu.SetActive(false);
        scoreText.text = time.timeText.text;
        Pause();
    }

    public void Change_State(bool state)
    {
        if (state)
            Restart();
        else
            Pause();
    }

    public void Pause()
    {
        game_paused = true;
        ingameanimator.Play("ingamemenuenter", -1, 0f);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        game_paused = false;
        Time.timeScale = 1;
        ingameanimator.Play("ingamemenuexit", -1, 0f);
    }
}
