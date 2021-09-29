using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAfterInteractionAction : MonoBehaviour
{

    private const int INFINITE = -1;
    // private const int NEVER = 0;
    private const int ONCE = 1;
    // private const int TWICE = 2;
    
    public int HowOftenAfterDialogueAction = 1;

    private int afterDialogueActionCount = 0;


    public void AfterInteractionAction()
    {
        if (afterDialogueActionCount < HowOftenAfterDialogueAction
            || HowOftenAfterDialogueAction == -1)
        {

            afterDialogueActionCount++;
            ExecuteAction();
        }
    }

    public abstract void ExecuteAction();
}
