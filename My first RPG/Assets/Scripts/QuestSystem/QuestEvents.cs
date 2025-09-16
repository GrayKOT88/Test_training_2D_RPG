using System;

public static class QuestEvents
{
    public static Action<QuestSO> OnQuestOfferRequested;
    public static Action<QuestSO> OnquestTurnInRequested;
    public static Action<QuestSO> OnQuestAccepted;

    public static Func<QuestSO, bool> IsQuestComplete;
}
