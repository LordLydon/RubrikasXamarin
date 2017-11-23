﻿using System;
using System.Reactive.Linq;

namespace RubrikasMasterDetail.Models
{
    public class Evaluation : BaseModel
    {
        private string description;
        private string name;
        private string rubricId;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref name, value);
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref description, value);
            }
        }

        public string RubricId
        {
            get => rubricId;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) SetProperty(ref rubricId, value);
            }
        }

        public static bool IsValid(Evaluation item)
        {
            return !string.IsNullOrWhiteSpace(item.Name) &&
                   !string.IsNullOrWhiteSpace(item.Description) &&
                   !string.IsNullOrWhiteSpace(item.RubricId);
        }
    }
}