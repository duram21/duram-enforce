using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu(fileName = "PassiveData", menuName = "Scriptable Objects/PassiveData")]
public class PassiveData : ScriptableObject
{
    public enum PassiveType {speed, Armor, Attack}

    [Header("# Main Info")]
    public PassiveType passiveType;
    public int passiveId;
    public string passiveName;
    [TextArea]
    public string passiveDesc;
    public Sprite passiveIcon;

    [Header("# Level Data")]
    public int[] cost;
    public float[] value;
    public float[] successRate;
    public float baseValue;
}
