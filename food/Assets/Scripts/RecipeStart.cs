using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeStart : MonoBehaviour
{
    public void StartRecipe()
    {
        FindObjectOfType<Boodschappenlijst>().BoodschappenlijstManagerStart();
    }
}
