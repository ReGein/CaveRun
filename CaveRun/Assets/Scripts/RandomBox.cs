using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBox : MonoBehaviour
{
    public GameManager manager;
    public GameObject mi;
    public PlayerMove player;
    public HpControll Hp;
    public MonsterWavve monster;
    public TimeM tM;
    public Shield shield;

    public bool isOn = false;
    public int random;
    public Text itemText;

    public void RandomItem()
    {
        random = Random.Range(1, 8);
        tM.TimerOn = true;
        itemText.gameObject.SetActive(true);
        manager.SfxPlay(GameManager.Sfx.item);
        switch (random)
        {
            case 1:
                player.JumpKing();
                itemText.text = "������ ��ȭ";
                player.isJumpK = true;
                break;
            case 2:
                player.JumpPD();
                itemText.text = "������ ����";
                player.isJumpP = true;
                break;
            case 3:
                monster.Respawn();
                itemText.text = "���� ���̺�";
                break;
            case 4:
                Hp.HpDown_Down();
                itemText.text = "HP���ҷ� ����";
                Hp.isDown = true;
                break;
            case 5:
                Hp.HpDown_UP();
                itemText.text = "HP���ҷ� ����";
                Hp.isUp = true;
                break;
            case 6:
                mi.gameObject.SetActive(true);
                itemText.text = "ȭ�� ����";
                break;
            case 7:
                shield.shieldOn();
                itemText.text = "��ȣ�� ����";
                break;
        }
    }
}
