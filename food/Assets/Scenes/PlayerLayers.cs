using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayers : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
        playerRenderer.sortingOrder = (int)(playerRenderer.transform.position.y * -25); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerRenderer.sortingOrder = (int)(playerRenderer.transform.position.y * -25);
    }
}
