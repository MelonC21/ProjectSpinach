using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Selector : P2Node
{
    public P2Selector(string p)
    {
        p2name = p;
    }

    public override P2Status Process()
    {
        P2Status childstatus = p2children[currentP2Child].Process();
        if (childstatus == P2Status.RUNNING) return P2Status.RUNNING;

        if (childstatus == P2Status.SUCCESS)
        {
            currentP2Child = 0;
            return P2Status.SUCCESS;
        }

        currentP2Child++;
        if (currentP2Child >= p2children.Count)
        {
            currentP2Child = 0;
            return P2Status.FAILURE;
        }

        return P2Status.RUNNING;
    }
}
