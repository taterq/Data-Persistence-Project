using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private ScoreRank scoreRank;
    // Start is called before the first frame update
    void Start()
    {
        scoreRank = GameObject.Find("ScoreRank").GetComponent<ScoreRank>();
        bestScoreText.text = "Best Score : " + scoreRank.instance.data.names[0] + " : " + scoreRank.instance.data.scores[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoScoreRank()
    {
        SceneManager.LoadScene(2);
    }
}
