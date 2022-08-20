using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Quest Data")]
public class QuestData_SO : ScriptableObject
{
    //單獨的類
    [System.Serializable]
    public class QuestRequire
    {
        public string name;
        public int requireAmount;
        public int currentAmount;
    }



    public string questName;

    [TextArea]
    public string description;

    public bool isStarted;

    public bool isCompleted; //未領獎勵

    public bool isFinished;

    public List<QuestRequire> questRequires = new List<QuestRequire>();




}
