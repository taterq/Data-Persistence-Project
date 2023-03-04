using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreRankUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreRankText;
    [SerializeField] private ScoreRank scoreRank;
    [SerializeField] private GameObject rankingPrefab;
    [SerializeField] private int[] yPos = {-150,-200,-250,-300,-350,-400,-450,-500,-550,-600,-100 };
    // Start is called before the first frame update
    void Start()
    {
        scoreRank = GameObject.Find("ScoreRank").GetComponent<ScoreRank>();
        UpdateScoreRank();
    }

    // Update is called once per frame
    void UpdateScoreRank()
    {
        GameObject prefab=
            Instantiate(rankingPrefab);
        prefab.transform.SetParent(gameObject.transform);
        prefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, yPos[10],0);
        for (int i = 0; i < 10; i++)
        {
            prefab =
                Instantiate(rankingPrefab);
            prefab.transform.SetParent(gameObject.transform);
            prefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, yPos[i], 0);
            RankingItem item = prefab.GetComponent<RankingItem>();
            item.ranking.text = i.ToString();
            item.playerName.text = scoreRank.instance.data.names[i];
            item.score.text = scoreRank.instance.data.scores[i].ToString();
        }

    }
    public void BackToGame()
    {
        SceneManager.LoadScene(1);
    }
}
