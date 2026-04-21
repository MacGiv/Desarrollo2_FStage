using UnityEngine;

public class Basic_DestroyTimer : MonoBehaviour
{
    [SerializeField] float countdown = 1.0f;

    void Start()
    {
        Destroy(gameObject, countdown);
    }
}
