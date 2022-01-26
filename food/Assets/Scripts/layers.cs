using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in spriteRenderers) { renderer.sortingOrder = (int) (renderer.transform.position.y*-25); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
