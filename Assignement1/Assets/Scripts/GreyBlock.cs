using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GreyBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer mySpriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite spriteInteractable;

    private Collider2D[] collidersInRange;

    [SerializeField]
    private float checkRadius = 1.5f;

    [SerializeField]
    private LayerMask groundTilesLayer;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = mySpriteRenderer.sprite;
    }

    private void Start()
    {
        collidersInRange = Physics2D.OverlapCircleAll(transform.position, checkRadius, groundTilesLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            other.GetComponent<PlayerInteract>().RemoveInteractible(this);

            mySpriteRenderer.sprite = initialSprite;
        }
    }

    public void Interact()
    {
        for (int i = 0; i < collidersInRange.Length; ++i)
        {
            collidersInRange[i].gameObject.GetComponent<GroundTile>().ToggleState();
        }
    }

}
