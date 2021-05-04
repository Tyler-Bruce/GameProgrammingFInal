using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private List<HighScoreEntry> scores;
    private HighScoreEntry hiscore;
    public Text names;
    public Text player_scores;

    private void Awake()
    {

        hiscore = GetScore();

        AddHighScoreEntry(hiscore.score, hiscore.name);

        string jsonString = PlayerPrefs.GetString("hiscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        scores = highscores.hiscores;
        if (highscores == null)
        {
            AddHighScoreEntry(100000, "tyler");
            AddHighScoreEntry(2000, "tyler2");
            AddHighScoreEntry(100, "tyler43");
            AddHighScoreEntry(1000, "tyler4");
            AddHighScoreEntry(230000, "tyler5");
            AddHighScoreEntry(5600000, "tyler6");
            jsonString = PlayerPrefs.GetString("hiscoreTable");
            highscores = JsonUtility.FromJson<HighScores>(jsonString);
        }
        
        for (int i = 0; i < highscores.hiscores.Count; i++)
        {
            for (int j = i + 1; j < highscores.hiscores.Count; j++)
            {
                if (highscores.hiscores[j].score > highscores.hiscores[i].score)
                {
                    HighScoreEntry tmp = highscores.hiscores[i];
                    highscores.hiscores[i] = highscores.hiscores[j];
                    highscores.hiscores[j] = tmp;
                }
            }
        }

        if (highscores.hiscores.Count > 10)
        {
            DeleteLowestScore(highscores);
        }
        
        HighScores hiscores = new HighScores { hiscores = scores };
        string newJson = JsonUtility.ToJson(hiscores);
        foreach (HighScoreEntry hiscore in highscores.hiscores)
        {
            names.text += GetName(hiscore);
            player_scores.text += GetScore(hiscore);
        }

        PlayerPrefs.SetString("hiscoreTable", newJson);
        PlayerPrefs.Save();
        //Debug.Log(scores.Count);
        /*
        if (hiscores == null)
        {
            AddHighScoreEntry(100000, "tyler");
            AddHighScoreEntry(2000, "tyler2");
            AddHighScoreEntry(100, "tyler43");
            AddHighScoreEntry(1000, "tyler4");
            AddHighScoreEntry(230000, "tyler5");
            AddHighScoreEntry(5600000, "tyler6");
            jsonString = PlayerPrefs.GetString("highscoreTable");
            hiscores = JsonUtility.FromJson<HighScores>(jsonString);
        }
        */
    }
    public static void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("hiscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        
        highscores.hiscores.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("hiscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("hiscoreTable"));
    }

    public void DeleteLowestScore(HighScores hs)
    {
        hs.hiscores.RemoveAt(hs.hiscores.Count - 1);
    }
    public void DeleteEntrys()
    {
        string jsonString = PlayerPrefs.GetString("hiscoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        foreach (HighScoreEntry hiscore in highscores.hiscores.ToList())
        {
            highscores.hiscores.Remove(hiscore);
        }
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("hiscoreTable", json);
        PlayerPrefs.Save();
        names.text = "";
        player_scores.text = "";
    }

    public class HighScores
    {
        public List<HighScoreEntry> hiscores;
    }


    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;
        public string name;
    }

    public HighScoreEntry GetScore()
    {
        HighScoreEntry hiscore = new HighScoreEntry();
        hiscore.score = PlayerPrefs.GetInt("score", 1);
        hiscore.name = PlayerPrefs.GetString("name", "def");
        return hiscore;
    }

    public string GetName(HighScoreEntry entry)
    {
        string name = entry.name;
        return name + "\n";
    }

    public string GetScore(HighScoreEntry entry)
    {
        string score = entry.score.ToString();
        return score + "\n";
    }
}
