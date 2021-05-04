using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Scenes : MonoBehaviour
{

    public void NextScene()
    {
        Debug.Log("points = " + PointsManager.points.ToString());
        PlayerPrefs.SetInt("score", PointsManager.points);
        PlayerPrefs.SetString("name", Settings.playerName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
    }
}
