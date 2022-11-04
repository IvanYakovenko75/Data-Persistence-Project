using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerDetails : MonoBehaviour
{
    //это для хранения имени игрока
    //Это вызывается моим текстовым полем на экране при редактировании в конце()
    private string input;

    public void StorePlayerName(string inputName)
    {
        //Store player
        //input = inputName;
        Debug.Log(inputName);

        MainManager.Instance.playerName = inputName;
    }
}