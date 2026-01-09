using CoursePlus.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Interfaces.QuestionsChoice
{
    public interface IChoiceService
    {
        Task<IEnumerable<ChoiceDTO>> GetAllChoicesAsync(int questionId);
        Task<ChoiceDTO?> GetChoiceByIdAsync(int choiceId);
        Task AddChoiceAsync(CreateChoiceDTO dto);
        Task UpdateChoiceAsync(int choiceId, UpdateChoiceDTO dto);
        Task UpdateUserChoiceAsync(int choiceId, UpdateUserChoice dto);
        Task DeleteChoiceAsync(int choiceId);
    }
}
