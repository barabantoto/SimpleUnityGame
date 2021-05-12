using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{

    public Dropdown dropdown;
    public ForGame game;
    public Player player;
    public float maxSpeed;


    void Start()
    {
        if (PlayerPrefs.HasKey("DifficlyLevel"))
        {
            DifficlyLevel((int)PlayerPrefs.GetFloat("DifficlyLevel"));
            dropdown.value = (int)PlayerPrefs.GetFloat("DifficlyLevel");
        }
    }
    void Update()
    {
        if (game.isPlayerActive)
        {
            dropdown.GetComponent<Dropdown>().enabled = false;
        }
        
    }
    public void OnClickQuit()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Save(string name,float value)
    {
        PlayerPrefs.SetFloat(name, value);
        PlayerPrefs.Save();
    }
    public void DifficlyLevel(int level)
    {
        if (level == 0)
        {
            maxSpeed = 4;
            ChooseLevel(0.2f, 2);
            Save("DifficlyLevel", 0);

        }
        else if (level == 1)
        {
            maxSpeed = 6;
            ChooseLevel(0.2f, 3);
            Save("DifficlyLevel", 1);
        }
        else
        {
            maxSpeed = 8;
            ChooseLevel(0.2f, 5);
            Save("DifficlyLevel", 2);
        }
    }
    void ChooseLevel(float extraSpeed,float movingVelocity)
    {
        player.extraSpeed = extraSpeed;
        player.movingVelocity = movingVelocity;
    }
}
