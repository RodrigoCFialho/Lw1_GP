using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer mySpriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite spriteInteractable;

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float speed = 5f;

    private Transform playerTransform;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        initialSprite = mySpriteRenderer.sprite;

        Freeze();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Block"))
        {
            Freeze();
        }
    }

    private void Freeze()
    {
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTransform = other.transform;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteract>().SetInteractible(this);

            mySpriteRenderer.sprite = spriteInteractable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteract>().SetInteractible(null);

            mySpriteRenderer.sprite = initialSprite;
        }
    }

    public void Interact()
    {
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        if (transform.position.y > playerTransform.position.y)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, speed);
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -speed);
        }
    }
}
