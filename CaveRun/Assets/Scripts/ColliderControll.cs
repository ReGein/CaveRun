using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControll : MonoBehaviour
{
    public void collisionOn()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    public void collisionOff()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
