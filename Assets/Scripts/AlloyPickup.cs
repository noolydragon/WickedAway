// using UnityEngine;

// public class AlloyPickup : MonoBehaviour
// {
//     public enum PickUpType { Lithium, Sodium, Barium, Copper, Cesium, MagnesiumSulfate, Potassium }
//     [Header("Pickup Config: ")]
//     public int amount = 1;
//     public float duration = 5f;
//     public PickUpType pickUpType;
//     public AudioClip pickUpSound;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             PlayerPickup player = other.GetComponent<PlayerPickup>();
//             if (player != null)
//             {
//                 player.Collect(this);
//                 Destroy(gameObject);
//             }
//         }
//     }
// }
