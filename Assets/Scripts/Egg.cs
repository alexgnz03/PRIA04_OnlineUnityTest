using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Egg : MonoBehaviour
{
    [Header(" Physics Settings ")]
    [SerializeField] private float bounceVelocity;
    private Rigidbody2D rig;

    [SerializeField] private GameObject BWall;
    public Vector3 newPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController PlayerController))
        {
            Bounce(collision.GetContact(0).normal);
            PointsManager.GamePoints += 1;
        }
    }
    private void Bounce(Vector2 normal)
    {
        rig.velocity = normal * bounceVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == BWall)
        {
            transform.position = newPosition;

            // Frenar completamente el movimiento
            rig.velocity = Vector2.zero;
            rig.angularVelocity = 0f;

            Debug.Log("Tocó a: " + other.gameObject.name);
            
            if ((PointsManager.GamePoints-10) >= 0)
            {
                PointsManager.GamePoints -= 10;
            }
            else
            {
                PointsManager.GamePoints = 0;
            }
        }
    }
}
