using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 10;
    public float lifetime = 3f;

    public GameObject sparkleEffect;

    private bool wasHit = false;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !wasHit)
        {
            wasHit = true;

            if (!GameTimer.instance.gameEnded)
            {
                ScoreManager.instance.AddPoints(points);

                Debug.Log("Target Hit! +" + points + " points!");

                // Spawn sparkles
                if (sparkleEffect != null)
                {
                    GameObject sparkles = Instantiate(
                        sparkleEffect,
                        transform.position,
                        Quaternion.identity
                    );

                    Destroy(sparkles, 3f);
                }
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}