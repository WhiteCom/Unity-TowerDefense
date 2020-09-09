using UnityEngine;

public class WayPoints : MonoBehaviour
{
    /*
     * Transform array and an array is basically just a list of items and 
     * when we use transform whenever we want a list of game objects in our scene
   
     */
    public static Transform[] points;

    private void Awake() //find all of different objects 
    {
        //waypoints count
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
