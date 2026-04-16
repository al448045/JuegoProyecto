using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public Hole[] Holes;

    private void Awake()
    {
        Holes = GameObject.FindObjectsByType<Hole>(FindObjectsSortMode.None);
    }

    public List<Hole> SearchAvaliableHoles()
    {
        Hole[] CurrentHoles = Holes;
        List<Hole> AvaliableHoles = new List<Hole>();

        foreach (Hole hole in CurrentHoles)
        {
            if ((!hole.is_hole_occupied) && (hole.is_hole_active))
            {
                AvaliableHoles.Add(hole);
            }
        }
        return AvaliableHoles;
    }
    public void Change2HoleStates(Hole actualHole, bool actualState, Hole upcomingHole, bool nextState)
    {
        actualHole.is_hole_occupied = actualState;
        upcomingHole.is_hole_occupied = nextState;
    }

    public void Change1HoleState(Hole currentHole, bool state)
    {
        currentHole.is_hole_occupied = state;
    }

    public void ResetHoles()
    {
        foreach(Hole hole in Holes)
        {
            hole.is_hole_active = true;
            hole.is_hole_occupied = false;
        }
    }
}
