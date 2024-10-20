using ezygamers.cmsv1;

public class AnswerChecker
{
    public static bool CheckAnswer(QuestionBaseSO question, string selectedAnswer)
    {
        if (question.optionType == OptionType.Learning)
        {
            return true;
        }

        if (question.correctOptionID.Equals(selectedAnswer))
        {
            return true;
        }

        return false;
    }
}
