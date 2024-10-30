using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialogueBox; // Assign this in the inspector
    public TMP_Text dialogueText; // Assign this in the inspector
    public Image npcImage;

    private void Awake()
    {
        if (Instance == null)

        {
            Instance = this;
            dialogueBox.SetActive(false); // Hide the dialog box initially
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowDialogue(string message, Sprite npcSprite = null)
    {
        dialogueBox.SetActive(true);
        npcImage.sprite = npcSprite; // Set the NPC image if provided
        StartCoroutine(TypeDialogue(message));
    }

    public void HideDialogue()
    {
        if (dialogueBox == null)
        {
            Debug.LogWarning("Dialogue Box is null!");
            return;
        }

        dialogueBox.SetActive(false);
        dialogueText.text = ""; // Clear text when hiding
    }

    private IEnumerator TypeDialogue(string message)
    {
        dialogueText.text = ""; // Clear previous text
        foreach (char letter in message)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust typing speed here
        }
    }
}


