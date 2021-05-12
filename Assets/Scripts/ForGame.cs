using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForGame : MonoBehaviour
{
    public Canvas settings;
    public AudioClip[] Clips;
    public Player Player;
    public Text text;
    public Text TopText;
    public Camera GameCamera;
    public GameObject[] StartBlockPrefab;
    public GameObject[] MidleBlockPrefab;
    public GameObject[] EndBlockPrefab;
    public bool isPlayerActive;
    public GameObject playButton;   

    private float pos = 0f;
    int score = 1;
    int top;
    private void Start()
    {
        Time.timeScale = 0;
        Player.gameObject.SetActive(false);
        isPlayerActive = false;
        text.text = "Press space to start";
        if (PlayerPrefs.HasKey("top"))
        {
            top = PlayerPrefs.GetInt("top");
            TopText.text = "Top: " + top;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !isPlayerActive && !settings.enabled)
        {
            Time.timeScale = 1;
            Player.gameObject.SetActive(true);
            isPlayerActive = true;
            playButton.SetActive(false);
            GetComponent<AudioSource>().Stop();
        }
        if (Player != null)
        {
            CameraMove();
            if (score < 5000)
                CreateBlocks(StartBlockPrefab);
            else if (score < 10000)
                CreateBlocks(MidleBlockPrefab);
            else CreateBlocks(EndBlockPrefab);
        }
        else
        {
            EndGame();
        }
    }
    private void FixedUpdate()
    {
        if (Player != null && isPlayerActive)
        {
            if (Time.timeScale > 0 && Player.transform.position.x > 13)
                text.text = "Score: " + score;
            score++;
            if (score > top)
            {
                top = score;
                Save();
            }
            TopText.text = "Top: " + top;
            GetComponent<AudioSource>().loop = false;
            AudioManager();
        }
    }
    void CameraMove()
    {
        GameCamera.transform.position = new Vector3(
               Player.transform.position.x,
               GameCamera.transform.position.y,
               GameCamera.transform.position.z
               );
    }
    void CreateBlocks(GameObject[] BlockPrefab)
    {
        while (Player.transform.position.x > pos - 25)
        {
            int randomIndex = Random.Range(1, BlockPrefab.Length);
            if (pos == 0) randomIndex = 0;
            GameObject game = Instantiate(BlockPrefab[randomIndex]);
            game.transform.SetParent(this.transform);
            ForBlocks blocks = game.GetComponent<ForBlocks>();

            game.transform.position = new Vector3(pos + 10, 0, 0);
            pos += blocks.Size;
        }
    }
    void EndGame()
    {
        if (top < score)
        {
            top = score;
            Save();
        }
        TopText.enabled = true;
        text.text = "Score: " + score;
        if (Input.GetKeyDown("space")) SceneManager.LoadScene("SampleScene");
    }
    void Save()
    {
        PlayerPrefs.SetInt("top", top);
        PlayerPrefs.Save();
    }
    void AudioManager()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            int randomIndex = Random.Range(1, Clips.Length);
            GetComponent<AudioSource>().PlayOneShot(Clips[randomIndex]);
            GetComponent<AudioSource>().clip = Clips[randomIndex];
        }
    }
}
