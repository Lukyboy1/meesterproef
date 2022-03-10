using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneActive;
    public Animator cameraAnimator;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Boodschappenlijst.ingredientsCollected)
        {
            if (collision.tag == "Player")
            {
                isCutsceneActive = true;
                cameraAnimator.SetBool("Cutscene", true);
                Invoke(nameof(StopCutscene), 3f);
            }
            Debug.Log("werkt");
        }
    }

    void StopCutscene()
    {
        isCutsceneActive = false;
        cameraAnimator.SetBool("Cutscene", false);
    }
}
