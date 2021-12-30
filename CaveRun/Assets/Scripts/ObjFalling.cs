using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFalling : MonoBehaviour
{
    public GameObject player;
    public GameObject[] skyGround;

    public int count = 0;

    private void Update()
    {
        falling();
    }

    void falling()
    {
        if(Vector2.Distance(player.transform.position, skyGround[count].transform.position) <= 5) //플레이어와 오브젝트의 위치를 비교해서 나온 값이 5보다 작거나 같으면 
        {
            skyGround[count].gameObject.SetActive(false);
            count++;
        }
    }
}
