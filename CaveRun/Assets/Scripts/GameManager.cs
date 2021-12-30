using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("-----------[ Core ]")]
    public bool isOver = false;
    public bool isStart = false;
    public bool isClear = false;
    public int score;
    public int maxLevel;

    [Header("-----------[ UI ]")]
    public GameObject startGroup;
    public GameObject endGroup;
    public GameObject ClearGroup;
    public Text scoreText;
    public Text MaxScoreText;
    public Text subScoreText;
    public Text ClearScore;
    public Text StageText;

    [Header("-----------[ Audio ]")]
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { Button, item, coin, jump, Over };
    int sfxCursor;

    public GameObject HpBar;
    public GameObject Player;
    public PlayerMove playerM;
    public GameObject timer;
    public GameObject Ground;
    public GameObject ObjGroup;
    public GameObject StageM;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }
        MaxScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    public void GameStart()
    {
        timer.gameObject.SetActive(true);
        StageM.gameObject.SetActive(true);
        HpBar.gameObject.SetActive(true);
        ObjGroup.gameObject.SetActive(true);
        Ground.gameObject.SetActive(true);
        Player.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        MaxScoreText.gameObject.SetActive(true);
        StageText.gameObject.SetActive(true);
        startGroup.SetActive(false);
        isStart = true;

        bgmPlayer.Play();
        SfxPlay(Sfx.Button);
    }

    public void GameOver()
    {
        if (isOver)
        {
            return;
        }
        isOver = true;

        playerM.playerEnd();

        StartCoroutine("GameOverRoutine");
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(3f);

        // 최고 점수 갱신
        int maxScore = Mathf.Max(score, PlayerPrefs.GetInt("MaxScore"));
        PlayerPrefs.SetInt("MaxScore", maxScore);

        // 게임오버 UI 표시
        subScoreText.text = "점수 : " + scoreText.text;
        endGroup.SetActive(true);

        bgmPlayer.Stop();
        SfxPlay(Sfx.Over);
    }

    public void GameClear()
    {
        if (isClear)
        {
            return;
        }
        isClear = true;

        StartCoroutine("GameClearRoutine");
    }

    IEnumerator GameClearRoutine()
    {
        yield return new WaitForSeconds(1f);

        // 최고 점수 갱신
        int maxScore = Mathf.Max(score, PlayerPrefs.GetInt("MaxScore"));
        PlayerPrefs.SetInt("MaxScore", maxScore);

        // 게임오버 UI 표시
        ClearScore.text = "점수 : " + scoreText.text;
        ClearGroup.SetActive(true);

        bgmPlayer.Stop();
        SfxPlay(Sfx.Over);
    }

    public void Reset()
    {
        SfxPlay(Sfx.Button);
        StartCoroutine("ResetCoroutine");
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    private void LateUpdate()
    {
        scoreText.text = score.ToString();
    }
    public void SfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.Button:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                break;
            case Sfx.item:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                break;
            case Sfx.coin:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;
            case Sfx.jump:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case Sfx.Over:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
        }
        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }
}
