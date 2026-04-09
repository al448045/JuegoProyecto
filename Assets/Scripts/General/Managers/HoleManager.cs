using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public Hole[] Holes;

    private void Awake()
    {
        Holes = GameObject.FindObjectsByType<Hole>(FindObjectsSortMode.None);

        foreach(Hole hole in Holes)
        {
            Debug.Log("Hole: " + hole.name);
        }
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
    public void ChangeHoleState(Hole actualHole, Hole upcomingHole)
    {
        actualHole.is_hole_occupied = false;
        upcomingHole.is_hole_occupied = true;
    }
}
