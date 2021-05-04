using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text pointsText;
    public static int points;
    public Text livesText;
    public static int lives;

    public void Awake()
    {
        points = 0;
        pointsText.text = points.ToString();
        lives = Settings.lives;
        livesText.text = Settings.lives.ToString();
    }
    public void Update()
    {
        if (pointsText != null)
        {
            pointsText.text = points.ToString();
            livesText.text = lives.ToString(); 
        }
        
    }
    public void GainPoints()
    {
        points++;
    }

    public void LosePoints()
    {
        points--;
    }

    public void GainLives()
    {
        lives++;
    }

    public void LoseLives()
    {
        lives--;
    }
}
