using UnityEngine;

/// <summary>
/// MUST HAVE A EMPTY OR FILLED CLASS NAMED 'Destructible' TO WORK PROPERLY
/// 
/// THIS CLASS IS MENT FOR THINGS LIKE PROJECTILES THAT NEED TO DETECT COLLISIONS WITH OTHER OBJECTS.
/// OPTIONALLY: YOU CAN ENABLE SPAWNING A CONTACT OBJECT THAT
/// WILL SHOW YOU WHERE THE PROJECTILE LANDED IN THE SCENE.
/// </summary>

public class CollisionDetectionUniversal : MonoBehaviour
{
    [SerializeField]
    private bool spawnContactObject = false;

    [SerializeField]
    private GameObject contactMarkerPrefab;

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        Destructible destructible = other.gameObject.GetComponent<Destructible>();
        ContactPoint2D contactPoint = other.GetContact(0);

        if (destructible)
        {
            Vector2 hitPoint = contactPoint.otherCollider.transform.position;
            if (spawnContactObject)
            {
                GameObject marker = Instantiate(contactMarkerPrefab, hitPoint, Quaternion.identity);
                Collider2D collider = marker.GetComponent<Collider2D>();
                collider.enabled = false;
            }
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destructible destructible = other.gameObject.GetComponent<Destructible>();

        if (destructible)
        {
            Vector2 hitPoint = other.transform.position;
            if (spawnContactObject)
            {
                GameObject marker = Instantiate(contactMarkerPrefab, hitPoint, Quaternion.identity);
                Collider2D collider = marker.GetComponent<Collider2D>();
                collider.enabled = false;
            }
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Destructible destructible = other.gameObject.GetComponent<Destructible>();

        if (destructible)
        {
            Vector2 hitPoint = other.transform.position;
            if (spawnContactObject)
            {
                GameObject marker = Instantiate(contactMarkerPrefab, hitPoint, Quaternion.identity);
                Collider collider = marker.GetComponent<Collider>();
                collider.enabled = false;
            }
            Destroy(this.gameObject);
        }
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        Destructible destructible = other.gameObject.GetComponent<Destructible>();
        ContactPoint contactPoint = other.GetContact(0);

        if (destructible)
        {
            Vector2 hitPoint = contactPoint.otherCollider.transform.position;
            if (spawnContactObject)
            {
                GameObject marker = Instantiate(contactMarkerPrefab, hitPoint, Quaternion.identity);
                Collider collider = marker.GetComponent<Collider>();
                collider.enabled = false;
            }
            Destroy(this.gameObject);
        }
    }

}
