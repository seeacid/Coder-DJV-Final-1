using UnityEngine;
using TMPro;

public class LogPanel : MonoBehaviour
{
    protected static LogPanel current;

    public TextMeshProUGUI logLabel;

    void Awake()
    {
        current = this;
    }

    public static void Write(string message)
    {
        current.logLabel.text = message;
    }
}
