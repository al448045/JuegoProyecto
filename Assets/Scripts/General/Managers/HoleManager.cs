using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HoleManager : MonoBehaviour 
{

    public Hole[] Holes;

    public void Awake()
    {
        Holes = GameObject.FindObjectsByType<Hole>(FindObjectsSortMode.InstanceID);
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
