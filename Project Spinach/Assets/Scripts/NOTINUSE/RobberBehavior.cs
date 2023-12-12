using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Added by Victoria and Lyndsey
public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    public GameObject backDoor;
    public GameObject frontDoor;

    NavMeshAgent agent;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    [Range(0, 1000)]
    public int money = 800;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Sequence steal = new Sequence("Steal Something");
        Leaf goToDiamond = new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToBDoor = new Leaf("Go To Back Door", GoToBackDoor);
        Leaf goToFDoor = new Leaf("Go To Front Door", GoToFrontDoor);
        Leaf goToVan = new Leaf("Go to Van", GoToVan);
        Leaf hasGotMoney = new Leaf("Has Got Money", HasMoney);
        Selector opendoor = new Selector("Open Door");

        opendoor.AddChild(goToFDoor);
        opendoor.AddChild(goToBDoor);

        steal.AddChild(hasGotMoney);
        steal.AddChild(opendoor);
        steal.AddChild(goToDiamond);
        //steal.AddChild(goToBDoor);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        //tree.PrintTree();
    }

    public Node.Status HasMoney()
    {
        if (money >= 500)
            return Node.Status.FAILURE;
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToBackDoor()
    {
        return GoToDoor(backDoor);
    }

    public Node.Status GoToFrontDoor()
    {
        return GoToDoor(frontDoor);
    }

    public Node.Status GoToDiamond()
    {
        Node.Status s = GoToLocation(diamond.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            diamond.transform.parent = this.gameObject.transform;
        }
        return s;
    }

    public Node.Status GoToVan()
    {
        Node.Status s = GoToLocation(van.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            money += 3000;
            diamond.SetActive(false);
        }
        return s;
    }

    public Node.Status GoToDoor(GameObject door)
    {
        Node.Status s = GoToLocation(door.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            if (!door.GetComponent<Lock>().isLocked)
            {
                door.SetActive(false);
                return Node.Status.SUCCESS;
            }
            return Node.Status.FAILURE;
        }
        else
            return s;
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }

        else if (Vector3.Distance(agent.pathEndPosition, destination) >= 2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeStatus != Node.Status.SUCCESS)
            treeStatus = tree.Process();
    }
}
