using CoursePlus.Application.DTOs;
using CoursePlus.Application.Interfaces.Certifications;
using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Infrastructure
{
    public class ExamRepository : IExamRepository
    {
        private readonly CoursePlusContext _context;

        public ExamRepository(CoursePlusContext context)
        {
            _context = context;
        }
        public Task CreateExamWithQuestionsAsync(Exam exam, List<Question> questions)
        {
            throw new NotImplementedException();
        }

        public Task<ExamResponseDTO> GetExamDetailsAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamDTO?> GetExamMetaDataAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion?> GetExamQuestionAsync(int examId, int examQuestionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExamQuestion>> GetExamQuestionsAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetRandomQuestionsAsync(int courseId, int count)
        {
            var mainCourses = new List<string>() { "Angular", ".NET core", "Azure" };
            var courseIds = new List<int>();
            var courses = await _context.Courses.FindAsync(courseId);
            mainCourses.ForEach(e =>
            {
                if (e.ToLower().Equals(courses?.Title.ToLower()))
                {
                    courseIds = _context.Courses.Where(w => w.Title.ToLower().
                    StartsWith(courses.Title.ToLower())).Select(s => s.CourseId).ToList();
                }
            });
        }

        public Task<List<UserExam>> GetUserExamsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveExamStatusAsync(int examId, string feedback)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExamQuestionAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
