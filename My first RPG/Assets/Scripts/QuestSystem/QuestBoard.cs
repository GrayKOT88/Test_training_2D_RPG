using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    [SerializeField] private QuestSO questToOffer;
    [SerializeField] private QuestSO questToTurnIn;

    private bool playerInRange;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool canTurnIn = questToTurnIn != null && QuestEvents.IsQuestComplete?.Invoke(questToTurnIn) == true;

            if (canTurnIn)
            {
                QuestEvents.OnquestTurnInRequested?.Invoke(questToTurnIn);
            }
            else
            {
                QuestEvents.OnQuestOfferRequested?.Invoke(questToOffer);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
