using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerController : MonoBehaviour
{
    public TutorialController tutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.Next_Step();
            this.gameObject.SetActive(false);
        }
    }
}
