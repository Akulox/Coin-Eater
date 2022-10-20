using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<LevelManager>().CollectCoin();
        Destroy(gameObject);
    }
}
