using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class QuestManager : Singleton<QuestManager>
{
    [System.Serializable]
    public class QuestTask
    {
        public QuestData_SO questData;

        //property¤¤­º¦r¥À¤j¼g
        public bool IsStarted 
        {
            get { return questData.isStarted; }
            set { questData.isStarted = value; }
        }

        public bool IsFinished
        {
            get { return questData.isFinished; }
            set { questData.isFinished = value; }
        }

        public bool IsCompleted
        {
            get { return questData.isCompleted; }
            set { questData.isCompleted = value; }
        }

    }

    public List<QuestTask> tasks = new List<QuestTask>();

    public bool HaveQuest(QuestData_SO data)
    {
        if (data != null)
            return tasks.Any(q => q.questData.questName == data.questName);
        else return false;
    }


    public QuestTask GetTask(QuestData_SO data)
    {
        return tasks.Find(q => q.questData.questName == data.questName);
    }

}
