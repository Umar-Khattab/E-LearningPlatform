using E_LearningPlatform.Models;

namespace E_LearningPlatform.Interfaces
{
    public interface IAnswerService
    {
        Task<Answer> GetAnswerByIdAsync(int id);
        Task<Answer> GetAnswerByQuestionIdAsync(int questionId);
        Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(int userId);
        Task<Answer> CreateAnswerAsync(Answer answer);
        Answer UpdateAnswer(Answer answer);
        Task DeleteAnswerAsync(int id);
        Task <bool> IsCorrectAnswerAsync(int answerId,int questionId);

    }
}
