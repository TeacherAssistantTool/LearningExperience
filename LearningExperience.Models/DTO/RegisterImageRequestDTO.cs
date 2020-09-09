﻿using LearningExperience.Services.Factories.GameLevel;

namespace LearningExperience.Models.DTO
{
    public class RegisterImageRequestDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public GameLevelType GameLevelType { get; set; }
    }
}