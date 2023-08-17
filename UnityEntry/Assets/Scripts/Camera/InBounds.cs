using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBounds : MonoBehaviour
{
    public static bool IsInBounds(Vector3 pos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);
        if (screenPos.x < Screen.width && screenPos.x > 0 &&
            screenPos.y < Screen.height && screenPos.y > 0)
        {
            return true;
        }
        else return false;
    }
}
