using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite spriteVisited;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = mySpriteRenderer.sprite;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (mySpriteRenderer.sprite == initialSprite)
            {
                mySpriteRenderer.sprite = spriteVisited;

                GameManager.Instance.AddScore(-1f);
            }
        }
    }

    public void ToggleState()
    {
        if (mySpriteRenderer.sprite == initialSprite)
        {
            mySpriteRenderer.sprite = spriteVisited;
            GameManager.Instance.AddScore(-1f);
        }
        else
        {
            mySpriteRenderer.sprite = initialSprite;
            GameManager.Instance.AddScore(1f);
        }
    }
}
