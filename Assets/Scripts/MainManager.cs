using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
public static MainManager Instance; /*���������� ������� Singleton, ����������� ������� ����� ���� ��������� ���������� ���� ��� ����� ����������.*/

    // ����������, ����������� ��� ������� ������ ���������, ����� ������ ������� ����� �� ���������.
    public string playerName;
    public int currentScore;

    //����������, ����������� ����� �������� ���������, ����� ������ ������� ����� �� ���������.
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        //���� � ����� 2 MainManager, ���������� ���� MainManager
        //����������, ����� ������ �����, �� ������� �� �������������, �������� ������� ���� ����������� MainManager.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //�� ���� ��� ������������, �� ����������
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //�������� ������� ����.
            LoadHighScore();
    }

    //����� �������� �������� ������� �����
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //����� ��� ���������� ������ �� ������ �����
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    //����� ���������� ����� � �����.
    public void SaveHighScore(int currentScore, string playerName)
    {
        //������ ����� ��������� ������ ����������
        SaveData data = new SaveData();

        //���������, ��� ����� ���������
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //����� ������������ ���� ��������� � JSON � ������� JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        //�������, ����������� ����������� ����� File.WriteAllText ��� ������ ������ � ����.
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}