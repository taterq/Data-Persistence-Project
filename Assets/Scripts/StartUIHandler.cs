using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highestText;
    public TMP_InputField nameInput;
    private ScoreRank scoreRank;
    // Start is called before the first frame update
    void Start()
    {
        scoreRank = GameObject.Find("ScoreRank").GetComponent<ScoreRank>();
        scoreRank.instance.LoadData();
        highestText.text = "Best Score : " + scoreRank.instance.data.names[0] + " : " + scoreRank.instance.data.scores[0];
        if (scoreRank.instance.data.currentPlayer.Length == 0)
            scoreRank.instance.data.currentPlayer = "Player";
        nameInput.text = scoreRank.instance.data.currentPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerNameChange(string name)
    {
        scoreRank.instance.data.currentPlayer = name;
    }
    public void OnGameScence()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitClicked()
    {
        scoreRank.instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
