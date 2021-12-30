using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWavve : MonoBehaviour
{
    public GameObject groud;
    public GameObject Monster;

    public void Respawn()
    {
        groud.gameObject.SetActive(true);
        Monster.gameObject.SetActive(true);
    }
}
