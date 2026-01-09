using CoursePlus.Application.DTOs;
using CoursePlus.Application.Interfaces.QuestionsChoice;
using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly IChoiceRepository _choiceRepository;

        public ChoiceService(IChoiceRepository choiceRepository)
        {
            _choiceRepository = choiceRepository;
        }

        public async Task<IEnumerable<ChoiceDTO>> GetAllChoicesAsync(int questionId)
        {
            var choices = await _choiceRepository.GetAllChoicesAsync(questionId);

            // Manual mapping: Entity -> DTO
            return choices.Select(c => new ChoiceDTO
            {
                ChoiceId = c.ChoiceId,
                QuestionId = c.QuestionId,
                ChoiceText = c.ChoiceText,
                IsCode = c.IsCode,
                IsCorrect = c.IsCorrect
            });
        }

        public async Task<ChoiceDTO?> GetChoiceByIdAsync(int choiceId)
        {
            var choice = await _choiceRepository.GetChoiceByIdAsync(choiceId);
            if (choice == null) return null;

            return new ChoiceDTO
            {
                ChoiceId = choice.ChoiceId,
                QuestionId = choice.QuestionId,
                ChoiceText = choice.ChoiceText,
                IsCode = choice.IsCode,
                IsCorrect = choice.IsCorrect
            };
        }

        public async Task AddChoiceAsync(CreateChoiceDTO dto)
        {
            // Manual mapping: DTO -> Entity
            var choice = new Choice
            {
                QuestionId = dto.QuestionId,
                ChoiceText = dto.ChoiceText,
                IsCode = dto.IsCode,
                IsCorrect = dto.IsCorrect
            };

            await _choiceRepository.AddChoiceAsync(choice);
        }

        public async Task UpdateChoiceAsync(int choiceId, UpdateChoiceDTO dto)
        {
            var existingChoice = await _choiceRepository.GetChoiceByIdAsync(choiceId);
            if (existingChoice == null)
                throw new KeyNotFoundException($"Choice with ID {choiceId} not found.");

            // Manual mapping: DTO -> Entity
            existingChoice.ChoiceText = dto.ChoiceText;
            existingChoice.IsCode = dto.IsCode;

            await _choiceRepository.UpdateChoiceAsync(existingChoice);
        }

        public async Task UpdateUserChoiceAsync(int choiceId, UpdateUserChoice dto)
        {
            var existingChoice = await _choiceRepository.GetChoiceByIdAsync(choiceId);
            if (existingChoice == null)
                throw new KeyNotFoundException($"Choice with ID {choiceId} not found.");

            // Only updating the IDs for user choice
            existingChoice.ChoiceId = dto.ChoiceId;
            existingChoice.QuestionId = dto.QuestionId;

            await _choiceRepository.UpdateChoiceAsync(existingChoice);
        }

        public async Task DeleteChoiceAsync(int choiceId)
        {
            var choice = await _choiceRepository.GetChoiceByIdAsync(choiceId);
            if (choice == null)
                throw new KeyNotFoundException($"Choice with ID {choiceId} not found.");

            await _choiceRepository.DeleteChoiceAsync(choice);
        }
    }
}
