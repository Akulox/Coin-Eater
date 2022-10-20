using UnityEngine;

public class Spice : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<LevelManager>().Lose();
    }
}
