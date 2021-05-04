using UnityEngine;
using UnityEngine.UI;

public class GetSettings : MonoBehaviour
{
    //public Text lives;
    public Text pname;
    void Update()
    {
       // if (lives != null)
        //{
            //lives.text = Settings.lives.ToString();
            pname.text = "Currently Playing: " + Settings.playerName;
        //}
        
    }
}
