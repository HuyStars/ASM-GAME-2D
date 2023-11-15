using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isLeft, isRight, isTop;
    private float horizontalMove;
    private Rigidbody2D rb;

    private Animator amim;

    private bool ChamDat;

    public int tocdo;

    public int docao;

    private bool CheckHuong = true;

    private float traipphai;
    public string tennv;
    public Text txtPlayerName;
    public GameObject winSreen;
    private float horizontalInput;
    private bool hasCollided = false;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource collectAudio;
    [SerializeField] private AudioSource finishAudio;

    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        tennv = PlayerPrefs.GetString("tenNV", "");
        txtPlayerName.text = tennv;
        rb = GetComponent<Rigidbody2D>();
        amim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = transform.position;
        vector3.y = vector3.y + 0.5f;
        txtPlayerName.transform.position = vector3;
        traipphai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(traipphai * tocdo, rb.velocity.y);
        var fixz = transform.localRotation;
        fixz.z = 0;
        transform.localRotation = fixz;
        // amim.SetFloat("move", Mathf.Abs(traipphai));
        xoay();
        
        if (ChamDat)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                jumpAudio.Play();
                rb.AddForce(Vector2.up*docao, ForceMode2D.Impulse);
                amim.SetTrigger("jump");
                amim.SetFloat("idol", 0);
                ChamDat = false;
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
            {
                amim.SetFloat("idol", 1);
            }
        }
        MovePlayer();
    }

    public void tatAm()
    {
        jumpAudio.Pause();
        collectAudio.Pause();
        finishAudio.Pause();
    }

    // public void TanCong()
    // {
    //     amim.SetTrigger("attack");
    // }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "dat")
        {
            ChamDat = true;
            amim.SetFloat("idol", 1);
        }

        if (other.gameObject.tag == "kimcuong")
        {
            
            Destroy(other.gameObject, 0.5f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "kimcuong")
        {
            collectAudio.Play();
            Destroy(other.gameObject, 0.5f);
        }

        if (!hasCollided && other.gameObject.tag == "man1")
        {
            finishAudio.Play();
            StartCoroutine(LoadSceneAfterDelay(1f, currentLevel + 1)); // Chuyển màn hình sau 2 giây
            hasCollided = true; // Đảm bảo chuyển màn hình chỉ xảy ra một lần
            amim.SetTrigger("winn");
        }
        if (!hasCollided && other.gameObject.tag == "man2")
        {
            finishAudio.Play();
            StartCoroutine(LoadSceneAfterDelay(1f, currentLevel + 1)); // Chuyển màn hình sau 2 giây
            hasCollided = true; // Đảm bảo chuyển màn hình chỉ xảy ra một lần
            amim.SetTrigger("winn");
        }
        if (other.gameObject.tag == "wingame")
        {
            finishAudio.Play();
            Time.timeScale = 0;
            winSreen.SetActive(true);
            amim.SetTrigger("winn");
        }
    }
    IEnumerator LoadSceneAfterDelay(float delay, int newLevel)
    {
        yield return new WaitForSeconds(delay);

        // Lưu màn chơi mới trong PlayerPrefs
        PlayerPrefs.SetInt("CurrentLevel", newLevel);

        // Chuyển đến màn mới
        SceneManager.LoadScene(newLevel);
    }

    void xoay()
    {
        if (CheckHuong && traipphai < 0 || !CheckHuong && traipphai > 0)
        {
            CheckHuong = !CheckHuong;
            Vector3 di_chuyen = transform.localScale;
            di_chuyen.x = di_chuyen.x * -1;
            transform.localScale = di_chuyen;
        }
    }
    void flip()
    {
        CheckHuong = !CheckHuong;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Top()
    {
        if (ChamDat)
        {
            jumpAudio.Play();
            amim.SetFloat("idol", 0);
            amim.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, docao);
            ChamDat = false;
        }
    }

    public void PoiterDownLeft()
    {
        if (CheckHuong)
        {
            flip();
        }
        amim.SetFloat("move", 1);
        isLeft = true;
    }
    
    public void PoiterUpLeft()
    {
        amim.SetFloat("move", 0);
        isLeft = false;
    }

    public void PoiterDownRight()
    {
        if (!CheckHuong)
        {
            flip();
        }
        amim.SetFloat("move", 1);
        isRight = true;
    }

    public void PoiterUpRight()
    {
        amim.SetFloat("move", 0);
        isRight = false;
    }
    private void MovePlayer()
    {
        if (isLeft)
        {
            horizontalMove = -tocdo;
        }
        else if(isRight)
        {
            horizontalMove = tocdo;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
