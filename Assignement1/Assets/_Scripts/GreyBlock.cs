using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer mySpriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite spriteInteractable;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = mySpriteRenderer.sprite;
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
            other.GetComponent<PlayerInteract>().SetInteractible(null);

            mySpriteRenderer.sprite = initialSprite;
        }
    }
    public void Interact()
    {
        throw new System.NotImplementedException();
    }

   
}
