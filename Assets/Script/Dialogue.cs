using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string message; // Array of dialogue messages
    public Sprite npcSprite; // Sprite for the NPC
}
