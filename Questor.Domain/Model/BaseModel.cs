﻿namespace Questor.Domain.Model
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
