using UnityEngine;

public class PersonController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private GameObject scaredIndicator;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"A collider has entered the {nameof(PersonController)} trigger");

        scaredIndicator.SetActive(true);
        // find closest off-screen side and move person in that direction
        Vector2 newPosition = gameObject.transform.position.x < 0 
            // move left
            ? new Vector2(gameObject.transform.position.x - Screen.width / 2f, gameObject.transform.position.y)
            // move right
            : new Vector2(gameObject.transform.position.x + Screen.width / 2f, gameObject.transform.position.y);

        Debug.Log($"Moving Person {nameof(gameObject.name)} to {newPosition.normalized}");
        rb.linearVelocityX = newPosition.x * moveSpeed;
    }

    void OnBecameInvisible()
    {
        scaredIndicator.SetActive(false);
        Debug.Log($"Destroying Person {nameof(gameObject.name)} that moved off-screen");
        Destroy(gameObject);
    }
}
