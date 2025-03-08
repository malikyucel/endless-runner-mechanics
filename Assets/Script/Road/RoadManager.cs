using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] RoadPrfs;
    [SerializeField] GameObject startRoad;
    private Renderer oldRoad_1;
    private Renderer oldRoad_2;

    [Header("Setting")]
    public int roadCount = 0;
    private float zPos;

    private Queue<Renderer> roadListPlay = new Queue<Renderer>();

    public static RoadManager Increate;
    private void Awake() 
    {
        if(Increate == null)
        {
            Increate = this;
        }    
    }

    private void Start() 
    {
        zPos = startRoad.transform.position.z;
        oldRoad_2 = startRoad.GetComponent<Renderer>();

        for(int i = 0; i < RoadPrfs.Length; i++)
        {
            RoadSpawn();
        }
    }

    public void RoadSpawn()
    {
        int randomRoadPref = Random.Range(0,RoadPrfs.Length);
        GameObject newRoadSpawn = Instantiate(RoadPrfs[randomRoadPref], transform);
        oldRoad_1 = newRoadSpawn.GetComponent<Renderer>();
        roadListPlay.Enqueue(oldRoad_1);
        zPos += ((oldRoad_2.bounds.size.z / 2) + (oldRoad_1.bounds.size.z / 2));
        newRoadSpawn.transform.position = new Vector3(0,0,zPos);
        oldRoad_2 = oldRoad_1;
    }

    public void DestroyRoad()
    {
        Renderer oldRoad = roadListPlay.Dequeue();
        Destroy(oldRoad.gameObject);
    }
}
