using UnityEngine;

public class JsReceiver : MonoBehaviour
{
    public void ReceiveMessage(string msg)
    {
        Debug.Log("Unity received: " + msg);
    }
}

