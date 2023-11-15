using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameplayer : MonoBehaviour
{
    public InputField inputName;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tenNV"))
        {
            string luu = PlayerPrefs.GetString("tenNV");
            inputName.text = luu;
        }   
    }

    public void NhapTen()
    {
        string nhap = inputName.text;
        PlayerPrefs.SetString("tenNV", nhap);
    }
}
