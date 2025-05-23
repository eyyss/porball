using UnityEngine;

public class RedPortal : MonoBehaviour
{
    public AudioClip ballHitClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BallController ballController))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 currentVelocity = rb.linearVelocity;
                // 90 derece döndürme 
                Vector2 rotatedVelocity = new Vector2(currentVelocity.y, -currentVelocity.x);
                rb.linearVelocity = rotatedVelocity;
                ballController.ChangeTrailColor(Color.red);
                ballHitClip.PlayClip2D(this, 0.5f);
            }
        }
    }
}
