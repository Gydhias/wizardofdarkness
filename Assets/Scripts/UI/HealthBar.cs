using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI FillText;
    public Image Bar;

    void Start()
    {
        GameUIController.Instance.OnDamageTaken += UpdateHealthBar;
        FillText.text = "100" + "%";
        Bar.fillAmount = 1f;
    }

    public void UpdateHealthBar(int value)
    {
        FillText.text = PlayerController.Instance.PlayerStats.HP.ToString("#") + "%";
        Bar.fillAmount = (float)PlayerController.Instance.PlayerStats.HP / 100;
    }

    private void OnDestroy()
    {
        GameUIController.Instance.OnDamageTaken -= UpdateHealthBar;
    }
}
