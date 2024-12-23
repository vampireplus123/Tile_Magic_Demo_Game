using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Lấy vị trí spawn
    public Vector3 GetSpawnPointPosition()
    {
        return transform.position;
    }
}
