using System;
using System.Collections.Generic;
using API.Models.Entities;

namespace API.Interfaces
{
    public interface ILearningResourceRepository
    {
         IEnumerable<LearningResource> GetLearningResources();
         LearningResource GetLearningResourceById(int learningResourceId);
         void InsertLearningResource(LearningResource learningResource);
         void DeletetLearningResource(LearningResource learningResource);
         void UpdateLearningResource(LearningResource learningResource);
    }
}