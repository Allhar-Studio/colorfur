using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject tutorialObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateObjs();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeactivateObjs();
        }
    }

    private void ActivateObjs()
    {
        tutorialObj.SetActive(true);
    }

    private void DeactivateObjs()
    {
        tutorialObj.SetActive(false);
    }
}
