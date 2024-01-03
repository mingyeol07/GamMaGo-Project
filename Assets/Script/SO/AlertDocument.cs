using UnityEngine;

[CreateAssetMenu(fileName = "AlertData",menuName = "Data/AlertData",order = 2)]
public class AlertDocument : ScriptableObject
{
    public string title;
    public string desc;
    public Sprite img;
}
