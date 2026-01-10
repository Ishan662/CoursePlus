using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.DTOs
{
    public class ExamResponseDTO
    {
        public int ExamId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = String.Empty;
        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
        public List<UserExamQuestionsDTO> Questions { get; set; } = new();
    }
}
