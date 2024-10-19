using ezygamers.cmsv1;

public class AnswerChecker
{
    public static bool CheckAnswer(QuestionBaseSO question, string selectedAnswer)
    {
        //TODO: checking logic to be implemented...

        if (question.correctOptionID.Equals(selectedAnswer))
        {
            return true;
        }

        return false;
    }
}
