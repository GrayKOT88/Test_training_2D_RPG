using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCState { Default, Idle, Patrol, Wander, Talk}
    public NPCState currentSate = NPCState.Patrol;
    private NPCState defaultState;

    public NPC_Patrol patrol;
    public NPC_Wander wander;
    public NPC_Talk talk;

    private void Start()
    {
        defaultState = currentSate;
        SwitchState(currentSate);
    }

    public void SwitchState(NPCState newState)
    {
        currentSate = newState;

        patrol.enabled = newState == NPCState.Patrol;
        wander.enabled = newState == NPCState.Wander;
        talk.enabled = newState == NPCState.Talk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(NPCState.Talk);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(defaultState);
    }
}
