using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text time;
    public static float timer;

    private void Start()
    {
        timer = Settings.timer;
        time.text = timer.ToString();
    }

    void Update()
    {
        if (time != null)
        {
            timer -= 1 * Time.deltaTime;
            time.text = timer.ToString();
            if (timer <= 0)
            {
                //Send score to end scene here
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }

    void SetScore()
    {
        
    }
}
