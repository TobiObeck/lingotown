using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MyScriptableObjects/DialogueSO", order = 1)]
public class DialogueSO : ScriptableObject
{
    public string npcName;

    [TextArea(3, 10)]
    public string[] sentencesForeign;

    [TextArea(3, 10)]
    public string[] sentencesNative;
}