using UnityEngine;

public class Movement : MonoBehaviour
{
    private static GameManager GameManager => GameManager.Singleton;

    private void Update()
    {
        transform.Translate(GameManager.speed * Time.deltaTime * Vector2.left);
    }
}
