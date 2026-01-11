using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoursePlus.Application.DTOs
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public int CourseId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public bool IsCode { get; set; }
        public bool HasMultipleAnswers { get; set; }
        public List<ChoiceDTO> Choices { get; set; } = new();

    }

    public class ExamQuestionDTO
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public bool IsCode { get; set; }
        public bool HasMultipleAnswers { get; set; }
        public List<ChoiceDTO> Choices { get; set; } = new();
    }

    public class UserExamQuestionDTO
    {
        public bool IsCorrect { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
    }

    public class CreateQuestionDTO
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Question text cannot exceed 500 characters.")]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Difficulty level cannot exceed 20 characters.")]
        public string DifficultyLevel { get; set; } = string.Empty;

        public bool IsCode { get; set; }
        public bool HasMultipleAnswers { get; set; }
    }

    public class UpdateQuestionDTO
    {
        [Required]
        [StringLength(500, ErrorMessage = "Question text cannot exceed 500 characters.")]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Difficulty level cannot exceed 20 characters.")]
        public string DifficultyLevel { get; set; } = string.Empty;

        public bool IsCode { get; set; }
        public bool HasMultipleAnswers { get; set; }
    }
}
