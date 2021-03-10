using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerController : MonoBehaviour
{
    public TutorialController tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.Next_Step();
            AudioManager.instance.Stop("Player Footstep");
            this.gameObject.SetActive(false);
        }
    }
}
