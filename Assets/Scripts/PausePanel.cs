using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public string pname;
    public int points;
    public int lives;
    public float time;

    [SerializeField]
    public Text playerName;
    [SerializeField]
    public Text Points;
    [SerializeField]
    public Text Lives;
    [SerializeField]
    public Text TimeText;
    [SerializeField]
    public GameObject menu;

    [SerializeField]
    public Toggle toggle;
    [SerializeField]
    public AudioSource music;

    public bool isPaused;

    private void Awake()
    {
        Unpause();
        pname = Settings.playerName;
        points = PointsManager.points;
        lives = PointsManager.lives;
        time = Timer.timer;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        pname = playerName.text;
        save.name = pname;
        points = PointsManager.points;
        save.points = points;
        lives = PointsManager.lives;
        save.lives = lives;
        time = Timer.timer;
        save.time = time;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            pname = save.name;
            playerName.text = pname;
            points = save.points;
            PointsManager.points = points;
            Points.text = points.ToString();
            PointsManager.lives = lives;
            Lives.text = lives.ToString();
            time = save.time;
            Timer.timer = time;
            TimeText.text = time.ToString();

        }
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Save as JSON: " + json);
    }
    private void PauseGame()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }

}