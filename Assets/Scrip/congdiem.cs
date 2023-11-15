using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;



public class congdiem : MonoBehaviour
{
    public int diemSo;
    public Text diemSoText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("diem"))
        {
            diemSo = PlayerPrefs.GetInt("diem");
            diemSoText.text = "x" + diemSo;
        }
    }

    private void Update()
    {
        diemSoText.text = "x" + diemSo;
        PlayerPrefs.SetInt("diem", diemSo);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "kimcuong")
        {
            diemSo++;
        }
    }
}