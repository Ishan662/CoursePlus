using CoursePlus.Application.DTOs;
using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Interfaces.Certifications
{
    public interface IExamRepository
    {
        Task<List<Question>> GetRandomQuestionsAsync(int courseId, int count);
        Task CreateExamWithQuestionsAsync(Exam exam, List<Question> questions);
        Task UpdateExamQuestionAsync(ExamQuestion examQuestion);
        Task<ExamQuestion?> GetExamQuestionAsync(int examId, int examQuestionId);
        Task<List<ExamQuestion>> GetExamQuestionsAsync(int examId);
        Task<List<UserExam>> GetUserExamsAsync(int userId);
        Task<ExamDTO?> GetExamMetaDataAsync(int examId);
        Task SaveExamStatusAsync(int examId, string feedback);
        Task<ExamResponseDTO> GetExamDetailsAsync(int examId);
    }
}
