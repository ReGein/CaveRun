using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeM : MonoBehaviour
{
    public float fTime = 0f;
    public float fLimitTime = 10f;
    public bool TimerOn = false;
    public Text itemText;
    public HpControll hp;
    public PlayerMove plyer;

    private void FixedUpdate()
    {
        if(fTime <= fLimitTime)
            Timer();
        else
        {
            BoolReset();
        }
    }

    void Timer()
    {
        if (TimerOn)
        {
            fTime += Time.deltaTime;
        }
    }

    public void BoolReset()
    {
        plyer.isJumpK = false;
        plyer.isJumpP = false;
        hp.isUp = false;
        hp.isDown = false;
        TimerOn = false;
        fTime = 0f;
        itemText.gameObject.SetActive(false);
    }
}