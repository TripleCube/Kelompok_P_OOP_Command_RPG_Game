using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public void Interact(string choice)
    {
        if (choice == "help")
        {
            Debug.Log("Anda membantu NPC tersebut, yang memberi Anda item.");
        }
        else if (choice == "ignore")
        {
            Debug.Log("Anda mengabaikan NPC tersebut dan melanjutkan perjalanan.");
        }
    }
}
