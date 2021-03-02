using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public LevelController level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            level.Level_Finished();
        }
    }
}
