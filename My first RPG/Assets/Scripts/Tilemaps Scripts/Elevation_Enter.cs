using UnityEngine;

public class Elevation_Enter : MonoBehaviour
{
    [SerializeField] private Collider2D[] _mountainColliders;
    [SerializeField] private Collider2D[] _boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach(Collider2D mountain in _mountainColliders)
            {
                mountain.enabled = false;
            }
            foreach(Collider2D boundary in _boundaryColliders)
            {
                boundary.enabled = true;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }
}