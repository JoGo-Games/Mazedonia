using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;
    private int tutorialstep = 1;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(First());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(tutorialstep)
            {
                case 1:
                    {
                        animator.Play("tutorial1endanim", -1, 0f);
                        tutorialstep += 1;
                        break;
                    }
                case 2:
                    {
                        animator.Play("tutorial2endanim", -1, 0f);
                        tutorialstep += 1;
                        Time.timeScale = 1;
                        break;
                    }
                case 3:
                    {
                        animator.Play("tutorial3endanim", -1, 0f);
                        tutorialstep += 1;
                        Time.timeScale = 1;
                        break;
                    }
                case 4:
                    {
                        animator.Play("tutorial4endanim", -1, 0f);
                        Time.timeScale = 1;
                        break;
                    }
            }
        }
    }

    IEnumerator First()
    {
        animator.Play("tutorial1enteranim", -1, 0f);
        yield return new WaitForSeconds(transitionTime);
    }

    public void Next_Step()
    {
        Time.timeScale = 0;
        switch (tutorialstep)
        {
            case 3:
                {
                    animator.Play("tutorial3enteranim", -1, 0f);
                    break;
                }
            case 4:
                {
                    animator.Play("tutorial4enteranim", -1, 0f);
                    break;
                }
        }
    }
}
