using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    //� ������ ���� ������ ������ ��� ��������� ����������� ��������
    // �� ���������� � ��������� ����������
    public Text bestScoreText;
    // ���������� ������ ��������� ���������������� ��������� � ��� � ����������
    // � ��������� ���������� ��������� Text (��������� ������ ���������� ���), ������� ���������� Text ��� �����
    // �� ����������� ������������ TextMeshPro

    void Start()
    {
        // ��������� ����������
        // ���� �� �� ������������ ��� �������, ���� ���������������� ��������� �� ����� �����, ����� � ��� ������� ����
        MainManager.Instance.LoadHighScore();

        Debug.Log("High Score is " + MainManager.Instance.highScore);
        //�� �������. ��� �����, ����� ��������� ��� ���������, ��� ��� ��������

        //����������� ����������� � ������
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

        //��� ���������� ���, ����� � ��� ����������
        //��������� ��� �����, ����� �� ����� ������
        /*if (MainManager.Instance != null)
        {
            
            //DisplayName(MainManager.Instance.playerName);
        }
        else
        {
            DisplayName("Ash Ketchum");
        }
        */
    }

    void DisplayHighScore()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", can you beat the High Score " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName + "?";
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }
}