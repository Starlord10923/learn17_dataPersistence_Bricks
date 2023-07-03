using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    // public TextMeshProUGUI scoreList;
void Awake()
    {
        SceneDataManager.Instance.LoadPlayerData();
        bestScoreText.text = "1)" + SceneDataManager.Instance.playerName + " : " + SceneDataManager.Instance.bestScore;
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif    
    }
    public void OnEndEdit(string name){
        SceneDataManager.Instance.playerName = name;
    }
}
