using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    private void Start()
    {
        SaveController.Instance.ResetGame();
        string lastWinner = SaveController.Instance.GetLastWinner();

        if (lastWinner != "")
            uiWinner.text = "Último vencedor: " + lastWinner;
        else
            uiWinner.text = "";
    }
}
