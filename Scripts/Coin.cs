using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinValue = 1;
    [SerializeField] AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void OnMouseDown()
    {
        // Alternative: collect on click
        CollectCoin();
    }

    private void CollectCoin()
    {
        CoinManager.Instance?.AddCoins(coinValue);
        
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Destroy(gameObject);
    }
}