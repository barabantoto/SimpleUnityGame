using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public Text SensitivityText;
    public Slider SenSlider;
    public Player player;
    void Start()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            SensitivityValue(PlayerPrefs.GetFloat("Sensitivity"));
        }
    }
    public void SensitivityValue(float sens)
    {
        sens = float.Parse(sens.ToString("#.#"));
        SenSlider.value = sens;
        SensitivityText.text = sens.ToString();
        Save("Sensitivity", sens);
        if (player)
            player.GetComponent<Rigidbody2D>().gravityScale = sens;
    }
    void Save(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
        PlayerPrefs.Save();
    }
}
