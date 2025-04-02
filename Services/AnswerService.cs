using E_LearningPlatform.Interfaces;
using E_LearningPlatform.Models;
namespace E_LearningPlatform.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AnswerService> _logger;

        public AnswerService(IUnitOfWork unitOfWork, ILogger<AnswerService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Getting answer with ID: {Id}", id);
                return await _unitOfWork.Repository<Answer>().FindAsync(predicate: a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting answer with ID: {Id}", id);
                throw;
            }
        }

        public async Task<Answer> GetAnswerByQuestionIdAsync(int questionId)
        {
            try
            {
                _logger.LogInformation("Getting answers for question ID: {QuestionId}", questionId);
                return await _unitOfWork.Repository<Answer>().FindAsync(a => a.QuestionId == questionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting answers for question ID: {QuestionId}", questionId);
                throw;
            }
        }

        public async Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(int userId)
        {
            try
            {
                _logger.LogInformation("Getting answers for user ID: {UserId}", userId);
                return await _unitOfWork.Repository<Answer>().FindAllAsync(criteria: a => a.StudentId == userId,10,0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting answers for user ID: {UserId}", userId);
                throw;
            }
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            try
            {
                _logger.LogInformation("Creating new answer for question ID: {QuestionId}", answer.QuestionId);
                await _unitOfWork.Repository<Answer>().AddAsync(answer);
                await _unitOfWork.SaveAsync();
                return answer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating answer for question ID: {QuestionId}", answer.QuestionId);
                throw;
            }
        }

        public Answer UpdateAnswer(Answer answer)
        {
            try
            {
                _logger.LogInformation("Updating answer with ID: {Id}", answer.Id);
                _unitOfWork.Repository<Answer>().Update(answer);
                _unitOfWork.Save();
                return answer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating answer with ID: {Id}", answer.Id);
                throw;
            }
        }

        public async Task DeleteAnswerAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting answer with ID: {Id}", id);
                var answer = await _unitOfWork.Repository<Answer>().FindAsync(predicate: a => a.Id == id);
                if (answer != null)
                {
                    _unitOfWork.Repository<Answer>().Delete(answer);
                    await _unitOfWork.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting answer with ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> IsCorrectAnswerAsync(int answerId, int questionId)
        {
            try
            {
                _logger.LogInformation("Checking if answer {AnswerId} is correct for question {QuestionId}", answerId, questionId);
                var answer = (await _unitOfWork.Repository<Answer>().FindAsync(
                    a => a.Id == answerId && a.QuestionId == questionId));

                return answer != null && answer.Question.QuestionAnswer == answer.StudentAnswer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking if answer {AnswerId} is correct for question {QuestionId}", answerId, questionId);
                throw;
            }
        }
    }
}
