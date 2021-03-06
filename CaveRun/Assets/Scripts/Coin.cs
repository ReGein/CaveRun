using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            manager.score += 10;
            gameObject.SetActive(false);
            manager.SfxPlay(GameManager.Sfx.coin);
        }
    }
}
