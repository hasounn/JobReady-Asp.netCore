namespace JobReady;

public enum UserAccountType
{
    Admin = 1,
    Student,
    Instructor,
    Company
}

public enum JobType
{
    Internship,
    EntryLevel,
    PartTime,
    Freelance,
    ResearchAssistant
}

public enum EngagementType
{
    Comment,
    Like,
    Report,
    Share
}

public enum RecommendationStatus
{
    Pending,
    Accepted,
    Rejected
}