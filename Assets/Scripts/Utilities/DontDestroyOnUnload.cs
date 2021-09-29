using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnUnload : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(this);
    }
}
