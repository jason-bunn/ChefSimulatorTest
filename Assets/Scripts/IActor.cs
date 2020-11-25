using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    void ReceiveAction(string name, IActor actor);
    void EmitAction(string name, IActor actor);
    string GetName();
}