using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public Animator animator;
    public GameObject mainmenu;
    public GameObject options;
    public GameObject levels;
    public float transitionTime;

    public void Change_scene(int menu)
    {
        StartCoroutine(Change_menu(menu));
    }

    IEnumerator Change_menu(int menu)
    {
        animator.Play("menutransitionanim", -1, 0f);

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
        }
    }
}
