using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float jumpForce = 5f;
    public float jumpCount = 0;
    bool doubleJump = false;
    bool isGround = false;
    public bool isDamage = false;
    public bool isJumpK = false;
    public bool isJumpP = false;

    bool DamageOn = false;
    bool isEnd = false;
    bool anim = false;
    public float MoveSpeed = 1000f;

    Rigidbody2D rb;
    Animator ani;
    Transform tr;
    SpriteRenderer sprite;

    public GameObject ClearPoint;
    public Shield shield;
    public GameObject random;
    public RandomBox RBox;
    public HpControll Hp;
    public TimeM tM;
    public ColliderControll CC;
    public GameObject Box;
    public GameManager manager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(rb.transform.position.y >= 3) // y�� 3�̻� �ö��� ��� ���� �ִϸ��̼��� ����
        {
            ani.SetBool("IsJump", false);
        }
        isDamage = false;

        if(!isDamage && !isEnd)
        {
            Movement();
            Silde();
        }

        if(ClearPoint.transform.position.x <= rb.transform.position.x)
        {
            manager.GameClear();
        }
    }

    void FixedUpdate() // �÷��̾ ���� �̵��ϱ� ���� ��
    {
        if(!DamageOn)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.AddForce(Vector2.right * MoveSpeed);
        }
    }

    public void Movement() // ������ ���� ��
    {
        if (rb.velocity.y == 0)
            isGround = true;
        else
            isGround = false;
        if (isGround)
            doubleJump = true;

        if (isGround && Input.GetButtonDown("Jump"))
        {
            if (jumpCount == 0)
            {
                JumpAddForce();
            }
        }
        else if(doubleJump && Input.GetButtonDown("Jump"))
        {
            if(jumpCount == 1)
            {
                JumpAddForce();
                doubleJump = false;
            }
        }
    }
    public void JumpAddForce() // ������ ���� �ִϸ��̼��� �۵�
    {
        if (!isJumpK && !isJumpP)
            jumpForce = 300f;
        else if (isJumpK)
            jumpForce = 400f;
        else if (isJumpP)
            jumpForce = 200f;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce);
        ani.SetBool("IsJump", true);
        jumpCount++;
        manager.SfxPlay(GameManager.Sfx.jump);
    }

    public void Silde() // �����̵� �۵�
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ani.SetBool("IsSilde", true);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            CC.collisionOn();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetBool("IsSilde", false);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            CC.collisionOff();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ��ü�� �΋H�� ���
    {
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            jumpCount = 0;
            doubleJump = true;
            ani.SetBool("IsJump", false);
        }

        if(collision.gameObject.tag.CompareTo("Obstacle") == 0 && !shield.OnShield)
        {
            isDamage = true;
            DamageOn = true;
            OnDamage();
            GameObject.Find("GameManager").GetComponent<HpControll>().isDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            Invoke("ReRun", 2);
            Invoke("OnDamageExit", 4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Potion") == 0)
        {
            Hp.HpPlus();
        }
        if (collision.gameObject.tag.CompareTo("Random") == 0)
        {
            RBox.RandomItem();
            random.gameObject.SetActive(false);
        }

    }

    void OnDamage() // �������� �޴� ��
    {
        if (isDamage)
        {
            gameObject.layer = 11;
            sprite.color = new Color(1, 1, 1, 0.4f);
            ani.SetTrigger("IsDamage");
            anim = true;
            ani.SetBool("IsJump", false);
            ani.SetBool("IsSilde", false);
        }
    }

    void OnDamageExit() // ���������� ��� ���
    {
        isDamage = false;

        if (!isDamage)
        {
            if (anim)
            {
                gameObject.layer = 0;
                sprite.color = new Color(1, 1, 1, 1);
            }
            anim = false;
        }
    }

    void ReRun()
    {
        ani.SetTrigger("IsRun");
        DamageOn = false;
    }

    public void playerEnd()
    {
        // ����ȿ�� ��Ȱ��ȭ
        ani.SetTrigger("IsEnd");
        isEnd = true;
        rb.simulated = false;

        if (jumpCount >= 1) // ���� ī���Ͱ� 1�̻��� ���
        {
            rb.transform.position = new Vector3(rb.transform.position.x, 0, 0);
        }
    }

    public void JumpKing() //���� �ð����� ������ ���
    {
        if (tM.fTime >= tM.fLimitTime && isJumpK)
        {
            tM.TimerOn = false;
            tM.BoolReset();
        }
    }

    public void JumpPD()   //���� �ð����� ��������
    {
        if (tM.fTime >= tM.fLimitTime && isJumpP)
        {
            tM.TimerOn = false;
            tM.BoolReset();
        }
    }
}