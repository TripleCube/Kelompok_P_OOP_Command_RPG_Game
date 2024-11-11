using System.Collections.Generic;
using UnityEngine;

public class MoralChoiceSystem : MonoBehaviour
{
    private Dictionary<string, bool> moralChoices = new Dictionary<string, bool>();

    public void MakeChoice(string choice, bool decision)
    {
        moralChoices[choice] = decision;
        ApplyConsequences(choice, decision);
    }

    private void ApplyConsequences(string choice, bool decision)
    {
        if (choice == "HelpNPC" && decision)
        {
            Debug.Log("NPC membantu Anda di masa depan.");
        }
        else if (choice == "HelpNPC" && !decision)
        {
            Debug.Log("NPC mengabaikan Anda.");
        }
    }
}
