using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject player;
    public bool OnShield = false;

    public void shieldOn()
    {
        gameObject.SetActive(true);
        OnShield = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            gameObject.SetActive(false);
            Invoke("ShieldOff", 0.1f);    //1초 후 실행
            Invoke("PlayerReset", 0.3f);    //3초 후 실행
        }
    }

    void ShieldOff()
    {
        OnShield = false;
        player.layer = 11;
    }

    void PlayerReset()
    {
        player.layer = 0;
    }
}