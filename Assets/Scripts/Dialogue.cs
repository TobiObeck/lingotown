using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public string npcName;
    
    [TextArea(3, 10)]
    public string[] sentencesForeign;
    public string[] sentencesNative;

}
