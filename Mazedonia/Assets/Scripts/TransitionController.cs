using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public Animator animator;
    public Animator mainmenuanimator;
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject levels;
    public GameObject controls;

    public float transitionTime;

    private void Start()
    {
        mainmenuanimator.Play("menuenteranim", -1, 0f);
    }

    public void Change_scene(int menu)
    {
        StartCoroutine(Change_menu(menu));
    }

    IEnumerator Change_menu(int menu)
    {
        
        animator.Play("menutransitionanim", -1, 0f);
        AudioManager.instance.Play("Menu Transition");

        yield return new WaitForSeconds(transitionTime);

        switch (menu)
        {
            case 1:
                {
                    mainmenu.SetActive(false);
                    levels.SetActive(true);
                    break;
                }
            case 2:
                {
                    levels.SetActive(false);
                    mainmenu.SetActive(true);
                    break;
                }
            case 3:
                {
                    mainmenu.SetActive(false);
                    credits.SetActive(true);
                    break;
                }
            case 4:
                {
                    credits.SetActive(false);
                    mainmenu.SetActive(true);
                    break;
                }
            case 5:
                {
                    mainmenu.SetActive(false);
                    options.SetActive(true);
                    break;
                }
            case 6:
                {
                    options.SetActive(false);
                    mainmenu.SetActive(true);
                    break;
                }
            case 7:
                {
                    mainmenu.SetActive(false);
                    controls.SetActive(true);
                    break;
                }
            case 8:
                {
                    controls.SetActive(false);
                    mainmenu.SetActive(true);
                    break;
                }
        }
    }
}
