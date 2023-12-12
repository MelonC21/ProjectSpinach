using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Node
{
    public enum P2Status { SUCCESS, RUNNING, FAILURE };
    public P2Status status;
    public List<P2Node> p2children = new List<P2Node>();
    public int currentP2Child = 0;
    public string p2name;

    public P2Node() { }

    public P2Node(string p)
    {
        p2name = p;
    }

    public virtual P2Status Process()
    {
        return p2children[currentP2Child].Process();
    }

    public void AddChild(P2Node p)
    {
        p2children.Add(p);
    }
}
