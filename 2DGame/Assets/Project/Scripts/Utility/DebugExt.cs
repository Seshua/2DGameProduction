using UnityEngine;

public static class DebugExt
{
    public static void Log(string message, bool shouldLog = true, string color = "white", int textSize = 12, bool bold = false, bool italic = false)
    {
        if (!shouldLog) return;

        string formattedMessage = message;

        if (italic) formattedMessage = $"<i>{formattedMessage}</i>";
        if (bold) formattedMessage = $"<b>{formattedMessage}</b>";
        formattedMessage = $"<color={color}><size={textSize}>{formattedMessage}</size></color>";

        Debug.Log(formattedMessage);
    }

    public static void Log(this Object contextObj, string message, bool shouldLog = true, string color = "white", int textSize = 12, bool bold = false, bool italic = false)
    {
        if (!shouldLog) return;

        string formattedMessage = message;

        if (italic) formattedMessage = $"<i>{formattedMessage}</i>";
        if (bold) formattedMessage = $"<b>{formattedMessage}</b>";
        formattedMessage = $"<color={color}><size={textSize}>{formattedMessage}</size></color>";

        Debug.Log(formattedMessage, contextObj);
    }
}
