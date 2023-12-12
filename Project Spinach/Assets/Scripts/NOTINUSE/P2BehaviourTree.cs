using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2BehaviourTree : P2Node
{
    public P2BehaviourTree()
    {
        p2name = "Tree";
    }

    public P2BehaviourTree(string p)
    {
        p2name = p;
    }

    public override P2Status Process()
    {
        return p2children[currentP2Child].Process();
    }


    struct NodeLevel
    {
        public int level;
        public P2Node node;
    }

    public void PrintTree()
    {
        string treePrintout = "";
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
        P2Node currentNode = this;
        nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

        while (nodeStack.Count != 0)
        {
            NodeLevel nextNode = nodeStack.Pop();
            treePrintout += new string('-', nextNode.level) + nextNode.node.p2name + "\n";
            for (int i = nextNode.node.p2children.Count - 1; i >= 0; i--)
            {
                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.p2children[i] });
            }
        }
        Debug.Log(treePrintout);
    }
}
