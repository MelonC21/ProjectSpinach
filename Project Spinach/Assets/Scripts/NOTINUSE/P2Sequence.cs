using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added by Victoria and Lyndsey
public class P2Sequence : P2Node
{
    public P2Sequence(string p)
    {
        p2name = p;
    }

    public override P2Status Process()
    {
        P2Status childstatus = p2children[currentP2Child].Process();
        if (childstatus == P2Status.RUNNING) return P2Status.RUNNING;
        if (childstatus == P2Status.FAILURE)
            return childstatus;

        currentP2Child++;
        if (currentP2Child >= p2children.Count)
        {
            currentP2Child = 0;
            return P2Status.SUCCESS;
        }

        return P2Status.RUNNING;
    }
}