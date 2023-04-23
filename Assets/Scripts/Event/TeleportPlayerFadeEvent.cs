using UnityEngine;
using UnityEngine.Events;
using BNG;


[System.Serializable]
public class TeleportPlayerFadeEvent : UnityEvent<Transform, ScreenFader>
{
}
