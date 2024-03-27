using UnityEngine;

public class collectable : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.GetComponent<LevelManager>().AddScore(1);
            Destroy(gameObject);
        }
    }
}
