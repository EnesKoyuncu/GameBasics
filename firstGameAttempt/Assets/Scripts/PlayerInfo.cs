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
        UpdateHPText(); // Oyunun baþýnda doðru deðer gösterilsin
    }


    public static void ChangeHP(int amount, PlayerInfo playerInfo)
    {
        PlayerHP += amount;
        PlayerHP = Mathf.Clamp(PlayerHP, 0, 100); // HP'yi 0-100 arasýnda sýnýrla
        playerInfo.UpdateHPText(); // Metni güncelle
    }

    private void UpdateHPText()
    {
        HPtext.text = "HP: "+ PlayerHP.ToString();
    }
}
