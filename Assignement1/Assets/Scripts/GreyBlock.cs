using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour, IInteractable
{
    private SpriteRenderer mySpriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite spriteInteractable;

    [SerializeField]
    private List<GroundTile> groundTilesList = new List<GroundTile>();

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

        if (other.CompareTag("Ground Tile"))
        {
            groundTilesList.Add(other.gameObject.GetComponent<GroundTile>());

            print("yes");
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
        print(groundTilesList.Count);

        for (int i = 0; i < groundTilesList.Count; ++i)
        {
            groundTilesList[i].ToggleState();
        }
    }
}
