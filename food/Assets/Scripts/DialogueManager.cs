using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public List<string> ingredientcollector;
    public List<string> ingredients;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f); //extra delay toevoegen
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        TriggerRecipe(nameText.text);
    }

    public void TriggerRecipe(string name)
    {
        int id = ingredientcollector.IndexOf(name);
        if (id >= ingredients.Count || id < 0)
        {
            return;
        }
        string ingredient = ingredients[id];
        Debug.Log(id);


        FindObjectOfType<Boodschappenlijst>().BoodschappenlijstManager(ingredient);
        
    }
}

