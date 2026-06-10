using System.Collections.Generic;
using UnityEngine;

public class NaivePathFinder
{
    private System.Func<Vector2Int, List<Vector2Int>> getNeighbours;
    private bool allowDiagonal;
    private int maxPathlength;

    // constructor
    public NaivePathFinder(
        System.Func<Vector2Int, List<Vector2Int>> getNeighbours,
        bool allowDiagonal = true,
        int maxPathlegnth = 100)
    {
        this.getNeighbours = getNeighbours;
        this.allowDiagonal = allowDiagonal;
        this.maxPathlength = maxPathlegnth;
    }

    public (List<Vector2Int> path, HashSet<Vector2Int> visited) FindPath(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();
        Vector2Int current = start;
        path.Add(current);
        visited.Add(current);

        return (path, visited);

        while (current != end)
        {
            Vector2Int next;
            if (allowDiagonal)
            {
              // TODO
            }
            else
            {
                next = GetNextCardinalNaivePosition(current, end);
            }

        }
    }

    private Vector2Int GetNextCardinalNaivePosition(Vector2Int current, Vector2Int target)
    {
        int dx = Mathf.Abs(target.x - current.x);
        int dy = Mathf.Abs(target.y - current.y);

        if (dx > dy)
        {
            int signX = target.x > current.x ? 1 : -1;
            Vector2Int next = current + new Vector2Int(signX, 0); 
            if (IsValidMove(next))
            {
                return next;
            }

            
            int signY = target.y > current.y ? 1 : -1;
            next = current + new Vector2Int(0, signY);
            if (IsValidMove(next))
            {
                return next;
            }
        }
        else
        {
            // try vertical movement
            int signY = target.y > current.y ? 1 : -1;
            Vector2Int next = current + new Vector2Int(0, signY);
            if (IsValidMove(next))
            {
                return next;
            }

            // if vertical fails try horizontal
            int signX = target.x > current.x ? 1 : -1;
            next = current + new Vector2Int(signX, 0);
            if (IsValidMove(next))
            {
                return next;
            }
        }

            return current; // no valid moves found
    }

    private bool IsValidMove(Vector2Int pos)
    {
        return getNeighbours(pos).Count < 0;
    }
}
