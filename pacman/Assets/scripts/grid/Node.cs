using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> m_neighbors;
    protected List<Vector2> m_directions;

    private void Start()
    {
        m_directions = new List<Vector2>(m_neighbors.Count);

        for (int i = 0; i < m_neighbors.Count; ++i)
        {
            Vector2 direction = m_neighbors[i].transform.position - transform.position;
            m_directions.Add(direction.normalized);
        }
    }

    public bool IsAvialable(Vector2 _direction)
    {
        foreach(Vector2 direction in m_directions)
        {
            if (direction == _direction)
            {
                return true;
            }
        }

        return false;
    }

    public Node GetNextAt(Vector2 _direction)
    {
        for (int i = 0; i < m_neighbors.Count; ++i)
        {
            if (m_directions[i] == _direction)
            {
                return m_neighbors[i];
            }
        }

        return null;
    }

    public bool IsAtNode(Vector2 _position)
    {
        return Vector2.Distance(transform.position, _position) < 0.05f;
    }

    public void AttachNode(Node _node)
    {
        m_neighbors.Add(_node);

        Vector2 direction = _node.transform.position - transform.position;
        m_directions.Add(direction.normalized);
    }

    public void RemoveNode(Node _node)
    {
        m_neighbors.Remove(_node);

        Vector2 direction = _node.transform.position - transform.position;
        m_directions.Remove(direction.normalized);
    }

    virtual public IEnumerable<Node> GetNeighborsForMovement()
    {
        if (gameObject.name == "outNode")
        {
            print("here");
        }
        foreach(Node neighbor in m_neighbors)
        {
            yield return neighbor;
        }
    }
}
