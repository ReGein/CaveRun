using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpControll : MonoBehaviour
{
    public Slider HpBar;
    public GameObject Player;
    public TimeM tM;
    public GameManager manager;
    public StageControll stageC;

    public bool isDamage = false;
    public bool isDown = false;
    public bool isUp = false;
    public GameObject[] HpPotion;

    private void Start()
    {
        Player.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeHpbar();

        if (HpBar.value == 0 || Player.transform.position.y <= -3)
        {
            EndHp();
        }
    }

    public void HpPlus()
    {
        HpBar.value += 50f;
        HpPotion[stageC.Count].gameObject.SetActive(false);
    }

    void HpDown()
    {
        if (GameObject.Find("Player").GetComponent<PlayerMove>().isDamage == true)
        {
            HpBar.value -= 10f;
            isDamage = false;
        }
    }

    void TimeHpbar()
    {
        if(!isDamage && !isDown && !isUp)
            HpBar.value -= 0.03f;
        else if(isDamage)
            HpDown();
        else if(isDown)
            HpBar.value -= 0.01f;
        else if(isUp)
            HpBar.value -= 0.1f;
    }

    void EndHp()
    {
        manager.GameOver();
    }

    public void HpDown_Down()    //일정 시간동안 HP 감소량 감소
    {
        if (tM.fTime >= tM.fLimitTime && isDown)
        {
            tM.TimerOn = false;
            tM.BoolReset();
        }
    }

    public void HpDown_UP()    //일정 시간동안 HP 감소량 증가
    {
        if (tM.fTime >= tM.fLimitTime && isUp)
        {
            tM.TimerOn = false;
            tM.BoolReset();
        }
    }
}
