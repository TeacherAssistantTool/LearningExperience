﻿using LearningExperience.Models.Interfaces;
using System;

namespace LearningExperience.Models
{


    public abstract class Document : IDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
