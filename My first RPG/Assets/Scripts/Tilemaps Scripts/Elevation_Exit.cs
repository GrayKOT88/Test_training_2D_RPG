using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{
    [SerializeField] private Collider2D[] _mountainColliders;
    [SerializeField] private Collider2D[] _boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in _mountainColliders)
            {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in _boundaryColliders)
            {
                boundary.enabled = false;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }
}