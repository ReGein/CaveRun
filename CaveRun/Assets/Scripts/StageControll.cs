using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageControll : MonoBehaviour
{
	public GameManager manager;
	public GameObject player;

	public GameObject[] point;
	public GameObject[] BackGround;
	public GameObject[] Ground;
	public GameObject[] ObjGroup;
	public Text StageText;

	public int StageIndex = 5;
	public int Count = 0;
	public int SCount = 0;
	bool Upbool = false;
	bool CountOn = true;

	private void Update()
	{
		OnStage();
	}

    public void OnStage()
	{
		if (GameObject.Find("GameManager").GetComponent<GameManager>().isStart == true && CountOn)
        {
			if(player.transform.position.x >= point[SCount].transform.position.x)
            {
				Upbool = false;
				CountOn = false;

				Invoke("StageUp", 1f); //0.1초 후
				SCount++;
			}
		}
	}

	void StageUp()
	{
		if (!GameObject.Find("GameManager").GetComponent<GameManager>().isOver && !Upbool && !CountOn) // 게임이 끝나지 않았을 경우 
		{
			Upbool = true;
			Count++;
		}

		if (Upbool && Count <= 5) // bool값이 true가 되고 카운트 값이 5 이하일 경우
		{
			textUp();
			Upbool = false;
			CountOn = true;
		}
	}

	void textUp()
    {
		switch (Count)
		{
			case 0:
				StageText.text = "Stage 1 Start Cave";
				break;
			case 1:
				StageText.text = "Stage 2 Red Cave";
				break;
			case 2:
				StageText.text = "Stage 3 Last Cave";
				break;
			default:
				StageText.text = "Stage default";
				break;
		}
	}
}
