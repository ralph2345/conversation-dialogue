using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public Dialogue dialogueData; // Assign this in the Inspector
    private bool isPlayerInRange = false;
    public Button interactButton; // Assign this in the Inspector
    public Button attackButton; // Assign this in the Inspector

    private void Awake()
    {
        if (interactButton != null)
        {
            interactButton.gameObject.SetActive(false);
            interactButton.onClick.AddListener(OnInteractButtonPressed);
        }

        if (attackButton != null)
        {
            attackButton.gameObject.SetActive(false);
            attackButton.onClick.AddListener(OnAttackButtonPressed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactButton != null)
            {
                interactButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactButton != null)
            {
                interactButton.gameObject.SetActive(false);
            }
            DialogueManager.Instance.HideDialogue();
           
            if (attackButton != null)
            {
                attackButton.gameObject.SetActive(false);
            }
        }
    }

    private void OnInteractButtonPressed()
    {
        if (isPlayerInRange)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        if (DialogueManager.Instance != null && !string.IsNullOrEmpty(dialogueData.message))
        {
            DialogueManager.Instance.ShowDialogue(dialogueData.message, dialogueData.npcSprite);
            StartCoroutine(WaitForInput());
        }
    }
    private IEnumerator WaitForInput()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0);

        // After the player interacts, show the attack button
        if (attackButton != null)
        {
            attackButton.gameObject.SetActive(true); // Show attack button after dialogue ends
        }
    }

    private void OnAttackButtonPressed()
    {
        Debug.Log("Attack button pressed!");
        if (attackButton != null)
        {
            attackButton.gameObject.SetActive(false); // Optionally hide the button after the action
        }
    }
}
