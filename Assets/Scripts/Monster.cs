using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Monster : MonoBehaviour
{
    private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private Rigidbody2D rigidbody2D;
    private int collectorLayer;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collectorLayer = LayerMask.NameToLayer("Collector");
        speed = 7;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity=new Vector2(speed,rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == collectorLayer)
        {
            Destroy(gameObject);
        }
    }
}
