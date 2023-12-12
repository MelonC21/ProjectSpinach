using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Leaf : P2Node
{
    public delegate P2Status Tick();
    public Tick ProcessMethod;

    public P2Leaf() { }

    public P2Leaf(string p, Tick pm)
    {
        p2name = p;
        ProcessMethod = pm;
    }

    public override P2Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        return P2Status.FAILURE;
    }
}
