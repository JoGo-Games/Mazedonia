using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 playerpos = player.transform.position;
        transform.position = new Vector3(playerpos.x, pos.y, playerpos.z + pos.z);
    }
}
