using UnityEngine;
using UnityEngine.UI;

public class ExplorationSystem : MonoBehaviour
{
    public Text displayText;

    public void Explore(string location)
    {
        switch (location)
        {
            case "village":
                displayText.text = "Anda berada di desa yang hancur akibat serangan musuh.";
                break;
            case "forest":
                displayText.text = "Anda tiba di hutan yang gelap dan penuh misteri.";
                break;
            case "castle":
                displayText.text = "Anda mendekati kastil yang gelap, tempat Lord of Shadows berada.";
                break;
            default:
                displayText.text = "Tidak ada tempat untuk dieksplorasi di sini.";
                break;
        }
    }
}
