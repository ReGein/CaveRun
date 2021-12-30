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
                itemText.text = "점프력 강화";
                player.isJumpK = true;
                break;
            case 2:
                player.JumpPD();
                itemText.text = "점프력 감소";
                player.isJumpP = true;
                break;
            case 3:
                monster.Respawn();
                itemText.text = "몬스터 웨이브";
                break;
            case 4:
                Hp.HpDown_Down();
                itemText.text = "HP감소량 감소";
                Hp.isDown = true;
                break;
            case 5:
                Hp.HpDown_UP();
                itemText.text = "HP감소량 증가";
                Hp.isUp = true;
                break;
            case 6:
                mi.gameObject.SetActive(true);
                itemText.text = "화력 지원";
                break;
            case 7:
                shield.shieldOn();
                itemText.text = "보호막 생성";
                break;
        }
    }
}
