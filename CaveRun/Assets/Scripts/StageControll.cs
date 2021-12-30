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

				Invoke("StageUp", 1f); //0.1�� ��
				SCount++;
			}
		}
	}

	void StageUp()
	{
		if (!GameObject.Find("GameManager").GetComponent<GameManager>().isOver && !Upbool && !CountOn) // ������ ������ �ʾ��� ��� 
		{
			Upbool = true;
			Count++;
		}

		if (Upbool && Count <= 5) // bool���� true�� �ǰ� ī��Ʈ ���� 5 ������ ���
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
