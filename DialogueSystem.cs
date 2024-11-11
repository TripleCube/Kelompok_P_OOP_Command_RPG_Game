using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;

    public void DisplayChoice(string choice)
    {
        if (choice == "good")
        {
            dialogueText.text = "Anda memilih untuk membantu, NPC sangat berterima kasih!";
        }
        else if (choice == "bad")
        {
            dialogueText.text = "Anda memilih untuk mengabaikan NPC, ia merasa kecewa.";
        }
    }
}
