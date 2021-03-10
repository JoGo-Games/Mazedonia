using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public bool game_paused = false;
    public MovementInput player;
    public GameObject ingamemenu;
    public Animator ingameanimator;
    public GameObject winmenu;
    public GameObject pausemenu;
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI scoreText;

    public int level_index;
    public float transitionTime;

    public TimerController timer;

    private void Start()
    {
        level_index = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Change_State(game_paused);
        }
    }

    public void Restart_Position()
    {
        AudioManager.instance.Play("Player Collision");
        player.Restart_Position();
    }

    public void Level_Finished()
    {
        AudioManager.instance.Stop("Main Theme");
        AudioManager.instance.Stop("Player Footstep");
        AudioManager.instance.Play("Victory Theme");
        AudioManager.instance.Play("Victory");
        winmenu.SetActive(true);
        pausemenu.SetActive(false);
        scoreText.text = timertext.text.ToString();
        float current_score = timer.Get_Score();
        Save_Score(current_score, scoreText.text);
        Change_State(false);
    }

    public void Change_State(bool state)
    {
        AudioManager.instance.Play("Menu Transition");
        if (state)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        game_paused = true;
        AudioManager.instance.Stop("Player Footstep");
        ingameanimator.Play("ingamemenuenter", -1, 0f);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        game_paused = false;
        Time.timeScale = 1;
        ingameanimator.Play("ingamemenuexit", -1, 0f);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Next_Level()
    {
        SceneManager.LoadScene(level_index+1);
        if (level_index + 1 > PlayerPrefs.GetInt("unlocked_level"))
        {
            PlayerPrefs.SetInt("unlocked_level", level_index + 1);
        }
    }

    public void Save_Score(float current_score, string current_scoretext)
    {
        if (PlayerPrefs.GetFloat("level" + level_index + "score") > current_score)
        {
            PlayerPrefs.SetFloat("level" + level_index + "score", current_score);
            PlayerPrefs.SetString("level" + level_index + "scoretext", current_scoretext);
        }
    }
}
