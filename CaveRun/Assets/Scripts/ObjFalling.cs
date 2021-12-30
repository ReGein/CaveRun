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
        if(Vector2.Distance(player.transform.position, skyGround[count].transform.position) <= 5) //�÷��̾�� ������Ʈ�� ��ġ�� ���ؼ� ���� ���� 5���� �۰ų� ������ 
        {
            skyGround[count].gameObject.SetActive(false);
            count++;
        }
    }
}
