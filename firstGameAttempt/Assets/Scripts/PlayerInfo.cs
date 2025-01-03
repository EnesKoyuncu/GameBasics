using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{


    public static int PlayerHP = 100;
    [SerializeField] TextMeshProUGUI HPtext;

    private void Start()
    {
        UpdateHPText(); // Oyunun ba��nda do�ru de�er g�sterilsin
    }


    public static void ChangeHP(int amount, PlayerInfo playerInfo)
    {
        PlayerHP += amount;
        PlayerHP = Mathf.Clamp(PlayerHP, 0, 100); // HP'yi 0-100 aras�nda s�n�rla
        playerInfo.UpdateHPText(); // Metni g�ncelle
    }

    private void UpdateHPText()
    {
        HPtext.text = "HP: "+ PlayerHP.ToString();
    }
}
