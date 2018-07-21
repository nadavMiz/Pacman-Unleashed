using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noDirectionNeighborNode : Node
{
    // public List<Node> m_neighbors;
    // protected List<Vector2> m_directions;
    public Vector2 m_unavialableDirection;

    override public IEnumerable<Node> GetNeighborsForMovement()
    {
        for (int i = 0; i < m_neighbors.Count; ++i)
        {
            if (m_directions[i] != m_unavialableDirection)
            {
                yield return m_neighbors[i];
            }
        }
    }

}
