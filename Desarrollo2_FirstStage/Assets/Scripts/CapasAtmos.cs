using UnityEngine;

public class CapasAtmos : MonoBehaviour
{
    [SerializeField] string text;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"You went through: {text} !");
    }

}
