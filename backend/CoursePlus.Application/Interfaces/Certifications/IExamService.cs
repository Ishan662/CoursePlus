using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Interfaces.Certifications
{
    public interface IExamService
    {
        Task<ExamDTO> StartExamAsync(int courseId, int userId);
        Task UpdateUserChoiceAsync(int id, UpdateUserQuestionChoiceDTO dto);
        Task<List<UserExamQuestionsDTO>> GetExamQuestionsAsync(int examId);
        Task<List<UserExam>> GetUserExamsAsync(int userId);

        Task<ExamDTO?> GetExamMetaData(int examId);
        Task SaveExamStatus(ExamFeedbackDTO examFeedback);

        Task<ExamResponseDTO> GetExamDetailsAsync(int examId);
    }
}
