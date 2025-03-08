using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            RoadManager.Increate.RoadSpawn();
            RoadManager.Increate.roadCount++;
            if(RoadManager.Increate.roadCount > 3)
            {
                RoadManager.Increate.DestroyRoad();
            }
        }
    }
}
