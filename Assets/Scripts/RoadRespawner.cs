using UnityEngine;

public class RoadRespawner : MonoBehaviour
{
    [SerializeField] private float roadEndPos = -9.8f;
    [SerializeField] private float newRoadPos = 27f;
    private void Update()
    {
        if (!(transform.position.x <= roadEndPos)) return;
        Instantiate(gameObject, new Vector2(newRoadPos, transform.position.y), Quaternion.identity);
        Destroy(this);
    }
}
