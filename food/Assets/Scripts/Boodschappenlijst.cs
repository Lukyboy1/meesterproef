using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boodschappenlijst : MonoBehaviour
{
    public TextMeshProUGUI boodschappenlijst;
    public TextMeshProUGUI regel1Text;
    public TextMeshProUGUI regel2Text;
    public TextMeshProUGUI regel3Text;
    public TextMeshProUGUI regel4Text;
    public TextMeshProUGUI regel5Text;
    public TextMeshProUGUI regel6Text;



    public Animator animator;
    public bool recipeActive;
    bool regel1;
    bool regel2;
    bool regel3;
    bool regel4;
    bool regel5;
    bool regel6;

    public static bool ingredientsCollected;

    // Start is called before the first frame update
    void Start()
    {
        ingredientsCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(regel1 && regel2 && regel3 && regel4 && regel5 && regel6 && !ingredientsCollected)
        {
            ingredientsCollected = true;
            Debug.Log("in de pan ermee");
        }
    }

    public void BoodschappenlijstManager(string ingredient)
    {
        if (regel1Text.text == ingredient)
        {
            regel1Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel1 = true;
        }
        if (regel2Text.text == ingredient)
        {
            regel2Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel2 = true;
        }
        if (regel3Text.text == ingredient)
        {
            regel3Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel3 = true;
        }
        if (regel4Text.text == ingredient)
        {
            regel4Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel4 = true;
        }
        if (regel5Text.text == ingredient)
        {
            regel5Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel5 = true;
        }
        if (regel6Text.text == ingredient)
        {
            regel6Text.color = new Color(0f, 0.8f, 0f, 1.0f);
            regel6 = true;
        }

    }
    public void BoodschappenlijstManagerStart()
    {
        animator.SetBool("IsOpen", true);

        regel1Text.text = "appels";

        regel2Text.text = "zalm";

        regel3Text.text = "brood";

        regel4Text.text = "eieren";

        regel5Text.text = "biefstuk";

        regel6Text.text = "wortels";
    }
}
