using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenManagement : Singleton<ScreenManagement>
{
    public string SceneTransitionName { get; private set; }
    public void SetTransitionName(string name)
    {
        this.SceneTransitionName = name;
    }
}