using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System.Transactions;

public class CandleSwap : MonoBehaviour
{
    [Header("Candle Assignment")]
    public GameObject flame;
    public CinemachineCamera cineCam;
    private GameObject m_startCandle;
    private bool m_isControllingStartCandle = true;
    public bool m_canSwitch = false;

    void Start()
    {
        m_startCandle = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_canSwitch)
        {
            m_canSwitch = false;
            Debug.Log("Swap Requested");
            SwapCandle(m_startCandle, false);
            SwapCandle(gameObject, true);
            cineCam = GameObject.FindFirstObjectByType<CinemachineCamera>();
            Transform playerTransform = GameObject.FindGameObjectWithTag("CinemachineTarget").transform;
        
            if (cineCam != null)
            {
                cineCam.Follow = playerTransform;
                cineCam.LookAt = playerTransform; 
            }
            m_isControllingStartCandle = false;
        }
    }

    public void SwapCandle(GameObject candle, bool activated)
    {
        //get and set the Character Controller of the new candle active
        candle.TryGetComponent<CharacterController>(out CharacterController endController);
        endController.enabled = activated;
        //get and set the ThirdPersonController of the new candle active
        candle.TryGetComponent<ThirdPersonController>(out ThirdPersonController thirdPersonController);
        thirdPersonController.enabled = activated;
        //get and set the PlayerInput of the new candle active
        candle.TryGetComponent<PlayerInput>(out PlayerInput playerInput);
        playerInput.enabled = activated;
        //get and set the StarterAssetInputs script of the new candle active
        candle.TryGetComponent<StarterAssetsInputs>(out StarterAssetsInputs starterAssetsInputs);
        starterAssetsInputs.enabled = activated;
        //get and set the Trigger Collider of the new candle inactive
        candle.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider);
        capsuleCollider.enabled = !activated;
        //get and set the candle swap script inactive on the candle swapping to
        candle.TryGetComponent<CandleSwap>(out CandleSwap candleSwap);
        candleSwap.enabled = !activated;
        m_startCandle = candle; //this switches the candle swapped to into the start candle to reset the logic
        //set the flame to active if active candle else set inactive
        if (activated)
        {
            flame.SetActive(true);
            //get and set the UpdateColorTint script of the new candle active
            flame.TryGetComponent<UpdateColorTint>(out UpdateColorTint updateColorTint);
            updateColorTint.enabled = true;
        }
        else
        {
            candleSwap.flame.SetActive(false);
            //get and set the UpdateColorTint script of the old candle inactive
            flame.TryGetComponent<UpdateColorTint>(out UpdateColorTint oldUpdateColorTint);
            oldUpdateColorTint.enabled = false;
        }
        candle.tag = activated ? "Player" : "CheckPoint";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        m_startCandle = other.gameObject;
        m_canSwitch = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        m_canSwitch = false;
    }
}
