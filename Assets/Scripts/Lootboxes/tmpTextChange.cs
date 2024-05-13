using UnityEngine;
using TMPro;

public class tmpTextChange : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    private int textValue = 0;

    public void ChangeText()
    {
        textValue++;
        tmpText.text = textValue.ToString();
    }
}
