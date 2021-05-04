using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    public InputField player;
    public Slider timer;
    public Dropdown lives;
    void Update()
    {
        Settings.playerName = player.text;
        Settings.timer = timer.value;
        Settings.lives = lives.value;
    }
}
