using System;
using UnityEngine;

public static class QuestEvents
{
    public static Action<QuestSO> OnQuestOfferRequested;
    public static Action<QuestSO> OnquestTurnInRequested;

    public static Func<QuestSO, bool> IsQuestComplete;
}
