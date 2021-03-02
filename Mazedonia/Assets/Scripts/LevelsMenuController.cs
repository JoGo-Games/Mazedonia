using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuController : MonoBehaviour
{
    public Animator animator;
    public GameObject current_level;
    public GameObject next_level_button;
    public GameObject levels_button;
    public GameObject levels_outside;
    public int level = 1;
    private int next_level;
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
                    }
                    break;
                }
            case true:
                {
                    if (level < 6)
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
                    }
                    break;
                }
        }
    }
}
