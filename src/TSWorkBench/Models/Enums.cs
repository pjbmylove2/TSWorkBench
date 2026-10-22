namespace TSWorkBench.Models
{
    public enum WorkType
    {
        FieldVisit,
        RemoteAnalysis,
        ProgramChange,
        HardwareFix,
        PreventiveCheck,
        Improvement,
        Inquiry,
        FollowUp,
        Other
    }

    public enum WorkStatus
    {
        Received,
        Analyzing,
        InProgress,
        Verifying,
        Done,
        OnHold,
        Canceled
    }

    public enum Priority
    {
        Urgent,
        High,
        Normal,
        Low
    }

    public enum TimelineKind
    {
        Contact,
        Call,
        Travel,
        OnSite,
        Remote,
        Analysis,
        Meeting,
        Note,
        StatusChange
    }
}
