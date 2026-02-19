using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool _hasPackage;
    [SerializeField] private float delay = 0.0F;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !_hasPackage)
        {
            _hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject, delay);
        }
        if (other.CompareTag("Customer") && _hasPackage)
        {
            _hasPackage = false;
            Destroy(other.gameObject, delay);
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
