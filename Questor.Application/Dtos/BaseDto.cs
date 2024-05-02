﻿namespace Questor.Application.Dtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
