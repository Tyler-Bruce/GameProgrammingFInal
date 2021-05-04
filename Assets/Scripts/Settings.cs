using UnityEngine;

public class Settings : MonoBehaviour
{
    public static string playerName;
    public static float timer;
    public static int lives;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
