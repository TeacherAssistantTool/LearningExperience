﻿using LearningExperience.Models.Model.ConcreteLevels;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualFiveShapesLevelGenerator: GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new EqualFiveShapesLevel();
        }
    }
}
