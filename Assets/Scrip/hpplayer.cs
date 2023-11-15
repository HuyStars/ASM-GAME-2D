using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpplayer : MonoBehaviour
{
    public static int mau = 3;

    public Image[] maus;
    public Sprite fullHP;
    public Sprite emptyHP;

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in maus)
        {
            img.sprite = emptyHP;
        }

        for (int i = 0; i < mau; i++)
        {
            maus[i].sprite = fullHP;
        }
    }
}
