using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    void ReceiveAction(IActor actor);
    void EmitAction(IActor actor);
}