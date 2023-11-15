using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cnmenu : MonoBehaviour
{
    public GameObject pauseMenuSreen;
    public GameObject LeverSreen;
    private int defaulDiem = 0;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void ChoiMoi()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("diem", defaulDiem);
        PlayerPrefs.SetInt("CurrentLevel", 1);
        hpplayer.mau = 3;
    }
    public void ChoiMoi2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("CurrentLevel", 2);
        hpplayer.mau = 3;
    }
    public void ChoiMoi3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("CurrentLevel", 3);
        hpplayer.mau = 3;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuSreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuSreen.SetActive(false);
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Luachon()
    {
        Time.timeScale = 0;
        LeverSreen.SetActive(true);
    }
    public void ThoatLuachon()
    {
        Time.timeScale = 0;
        LeverSreen.SetActive(false);
    }

    public void TiepTuc()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1); // Mặc định là màn 1 nếu không có thông tin lưu trữ
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
    }

}
