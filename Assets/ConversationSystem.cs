using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening; 

public class ConversationSystem : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject continueButton;
    public TMP_Text dialogueText;
    public TMP_Text leftCharacterNameText;
    public TMP_Text rightCharacterNameText;
    public Image leftCharacterImage;
    public Image rightCharacterImage;

    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        public string dialogue;
        public Sprite characterSprite;
        public bool isLeftCharacter; 
    }

    public DialogueLine[] dialogueConversation;
    private int index = 0;
    public float wordSpeed = 0.05f;

    void Start()
    {
        dialoguePanel.SetActive(true);
        continueButton.SetActive(false);
        StartCoroutine(Typing());
    }

    void Update()
    {
        if (dialogueText.text == dialogueConversation[index].dialogue)
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Typing()
    {
        
        dialogueText.text = "";
        UpdateCharacterDisplay();

        foreach (char letter in dialogueConversation[index].dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void UpdateCharacterDisplay()
    {
        DialogueLine currentLine = dialogueConversation[index];
        if (currentLine.isLeftCharacter)
        {
            leftCharacterNameText.text = currentLine.characterName;
            leftCharacterImage.sprite = currentLine.characterSprite;
            AnimateCharacter(leftCharacterImage, leftCharacterNameText);
            
            rightCharacterImage.gameObject.SetActive(false);
            rightCharacterNameText.gameObject.SetActive(false);
        }
        else
        {
            rightCharacterNameText.text = currentLine.characterName;
            rightCharacterImage.sprite = currentLine.characterSprite;
            AnimateCharacter(rightCharacterImage, rightCharacterNameText);
           
            leftCharacterImage.gameObject.SetActive(false);
            leftCharacterNameText.gameObject.SetActive(false);
        }
    }

    void AnimateCharacter(Image characterImage, TMP_Text characterNameText)
    {
        characterImage.gameObject.SetActive(true);
        characterNameText.gameObject.SetActive(true);

        characterImage.DOFade(1f, 0.5f).From(0f);
        characterNameText.DOFade(1f, 0.5f).From(0f);
        
        characterImage.transform.DOScale(1.1f, 0.5f).From(0.9f);
        characterNameText.transform.DOScale(1.1f, 0.5f).From(0.9f);
        
        dialogueText.DOFade(1f, 0.5f).From(0f);
    }

    public void NextLine()
    {
        continueButton.SetActive(false);

        if (index < dialogueConversation.Length - 1)
        {
            index++;
            StartCoroutine(Typing());
        }
        else
        {
            dialoguePanel.SetActive(false); 
        }
    }
}
