using UnityEngine;
using System.Collections.Generic;

public struct SortingMatcher
{
    public SpriteRenderer renderer;
    public int originalLayer;

    public SortingMatcher(SpriteRenderer r, int l)
    {
        renderer = r;
        originalLayer = l;
    }
}

public class SpriteLayerSorting : MonoBehaviour
{
    private List<SortingMatcher> spritesMatcher = new List<SortingMatcher>();

	private void Start ()
    {
        RegisterSpritesAndOrders();
	}
	
	private void Update ()
    {
        AutoSortLayers();
	}

    private void RegisterSpritesAndOrders()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        for (var i= 0; i < sprites.Length; i++)
        {
            spritesMatcher.Add(new SortingMatcher(sprites[i], sprites[i].sortingOrder));
        }
    }

    private void AutoSortLayers()
    {
        for (var i = 0; i < spritesMatcher.Count; i++)
        {
            spritesMatcher[i].renderer.sortingOrder = Mathf.RoundToInt(spritesMatcher[i].originalLayer - transform.position.y * 10); 
        }
    }
}
