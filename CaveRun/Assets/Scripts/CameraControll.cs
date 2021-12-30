using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        Vector3 PlayerPos = new Vector3(player.transform.position.x + 5, 1, -10);
        transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime * 2f);
    }
}
