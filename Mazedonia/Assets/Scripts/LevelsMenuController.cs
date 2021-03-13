using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelsMenuController : MonoBehaviour
{
    public Animator animator;
    public GameObject current_level;
    public GameObject next_level_button;
    public GameObject levels_button;
    public GameObject levels_outside;
    public GameObject leftarrow;
    public GameObject rightarrow;
    public TextMeshProUGUI highscore;

    public int level;
    private int next_level;

    private void Start()
    {
        level = PlayerPrefs.GetInt("unlocked_level");
        if (PlayerPrefs.GetInt("unlocked_level") == 1)
        {
            leftarrow.GetComponent<Button>().interactable = false;
        }
        rightarrow.GetComponent<Button>().interactable = false;
        animator.enabled = false;
        levels_button.GetComponent<RectTransform>().anchoredPosition = new Vector2((level-1)*-400.0f,0.0f);
        current_level = GameObject.Find("Level " + level);
        current_level.transform.SetParent(levels_button.transform);
        current_level.GetComponent<Button>().interactable = true;
        highscore.text = Get_Score();
    }

    public void Change_level(bool arrow)
    {
        switch (arrow)
        {
            case false:
                {
                    if (level > 1)
                    {
                        current_level.transform.SetParent(levels_outside.transform);
                        current_level.GetComponent<Button>().interactable = false;
                        next_level = level - 1;
                        next_level_button = GameObject.Find("Level " + next_level);
                        next_level_button.transform.SetParent(levels_button.transform);
                        next_level_button.GetComponent<Button>().interactable = true;
                        animator.Play("level" + level.ToString() + "to" + next_level.ToString(), -1, 0f);
                        level -= 1;
                        current_level = next_level_button;
                        if (rightarrow.GetComponent<Button>().interactable == false)
                            rightarrow.GetComponent<Button>().interactable = true;
                        if (level == 1)
                            leftarrow.GetComponent<Button>().interactable = false;
                    }
                    break;
                }
            case true:
                {
                    if (level < PlayerPrefs.GetInt("unlocked_level"))
                    {
                        current_level.transform.SetParent(levels_outside.transform);
                        current_level.GetComponent<Button>().interactable = false;
                        next_level = level + 1;
                        next_level_button = GameObject.Find("Level " + next_level);
                        next_level_button.transform.SetParent(levels_button.transform);
                        next_level_button.GetComponent<Button>().interactable = true;
                        animator.Play("level" + level.ToString() + "to" + next_level.ToString(), -1, 0f);
                        level += 1;
                        current_level = next_level_button;
                        if (leftarrow.GetComponent<Button>().interactable == false)
                            leftarrow.GetComponent<Button>().interactable = true;
                        if (level == PlayerPrefs.GetInt("unlocked_level"))
                            rightarrow.GetComponent<Button>().interactable = false;
                    }
                    break;
                }
        }
        Debug.Log(level);
        highscore.text = Get_Score();
    }

    public void Start_Level()
    {
        SceneManager.LoadScene(level);
    }

    public string Get_Score()
    {
        PlayerPrefs.GetFloat("level" + level + "score", 0.0f);
        return PlayerPrefs.GetString("level" + level + "scoretext", "00:00:00");
    }
}
