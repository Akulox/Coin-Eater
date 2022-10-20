using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject explosion;
    public Player player;
    public int coinCount;
    public int coinCollected;
    public Text coinCountText;
    public bool isPlaying;

    public GameObject restartWindow;
    public Text resultText;
    private void Start()
    {
        coinCount = FindObjectsOfType<Coin>().Length;
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinCountText.text = $"{coinCollected}/{coinCount}";
    }
    public void CollectCoin()
    {
        if (coinCount == ++coinCollected)
        {
            Win();
        }
        UpdateCoinText();
    }

    public void Win()
    {
        player.path.Clear();
        resultText.text = "You won";
        isPlaying = false;
        restartWindow.SetActive(true);
    }

    public void Lose()
    {
        player.path.Clear();
        Instantiate(explosion, player.transform.position, quaternion.identity);
        Destroy(player.gameObject);
        resultText.text = "You lost";
        isPlaying = false;
        restartWindow.SetActive(true);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(0);  
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (Input.GetMouseButtonUp(0))
            {
                player.path.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition) 
                                - new Vector3(0,0, Camera.main.transform.position.z));
            }
            else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                player.path.Add(Camera.main.ScreenToWorldPoint(Input.touches[0].position) 
                                - new Vector3(0,0, Camera.main.transform.position.z));
            }
        }
    }
}
