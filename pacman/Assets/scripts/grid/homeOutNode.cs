using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeOutNode : Node
{

    public Node m_centralNode;

    // public List<Node> m_neighbors;
    // protected List<Vector2> m_directions;
    public Vector2 GetDirectionToCentralNode()
    {
        Vector2 direction = m_centralNode.transform.position - transform.position;
        return direction.normalized;
    }

    override public IEnumerable<Node> GetNeighborsForMovement()
    {
        foreach (Node node in m_neighbors)
        {
            if (node != m_centralNode)
            {
                yield return node;
            }
        }
    }
}
